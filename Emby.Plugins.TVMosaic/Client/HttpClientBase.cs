// <copyright file="HttpClientBase.cs" >
// Copyright (c) 2017 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares André</author>
// <date>11.09.2017</date>
// <summary>Implements the HTTP client base class</summary>
using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Collections.Concurrent;
using TSoft.TVServer.Entities;
using TSoft.TVServer.Constants;
using TSoft.TVServer.Interfaces;
using TSoft.TVServer.Helpers;
using MediaBrowser.Model.Logging;
using MediaBrowser.Model.LiveTv;
using Emby.Plugins.TVMosaic;

namespace TSoft.TVServer
{
	/// <summary> A HTTP client base. </summary>
	public abstract class HttpClientBase
	{
		/// <summary>
		/// Initializes a new instance of the TSoft.TVServer.HttpClientBase class. </summary>
		/// <param name="logger"> The logger. </param>
		public HttpClientBase(ILogger logger)
		{
			this._Logger = logger;
		}

		/// <summary> The logger. </summary>
		protected readonly ILogger _Logger;

		/// <summary> The serializers. </summary>
		protected readonly ConcurrentDictionary<string, XmlSerializer> _Serializers = new ConcurrentDictionary<string, XmlSerializer>();

		/// <summary>
		/// Deserialize this TSoft.TVServer.HttpClientBase to the given stream. </summary>
		/// <typeparam name="valueType"> Type of the value type. </typeparam>
		/// <param name="xml"> The XML. </param>
		/// <returns> A valueType. </returns>
		public valueType Deserialize<valueType>(string xml)
		{
			try
			{
				if (!string.IsNullOrEmpty(xml))
				{
					using (var stringReader = new StringReader(xml))
					{
						using (var reader = new XmlTextReader(stringReader))
						{
							reader.Namespaces = false;
							//var serializer = this.GetSerializer(typeof(valueType));
							XmlSerializer serializer = new XmlSerializer(typeof(valueType));
							object serializerDeserialize = serializer.Deserialize(reader);
							return (valueType)serializerDeserialize;
						}
					}
				}
				else
				{
					return default(valueType);
				}
			}
			catch (Exception ex)
			{
				this._Logger.ErrorException("Cannot deserialize Data : {0}", ex, xml);
				return default(valueType);
			}
		}

		/// <summary> Gets response asynchronous. </summary>
		/// <typeparam name="T"> Generic type parameter. </typeparam>
		/// <param name="request_object"> The request object. </param>
		/// <param name="cancellationToken"> The cancellation token. </param>
		/// <returns> The asynchronous result that yields the response asynchronous. </returns>
		public async Task<Response> GetResponseAsync<T>(T request_object, TunerHostInfo tuner, TvMosaicProviderOptions options, CancellationToken cancellationToken) where T : IRequest
		{
			Response response;
			string xml_string;

			xml_string = Serialize<T>(request_object);
			var command = this.GetHttpHeaderDictionary(request_object.HttpCommand, xml_string);
			var textStream = await this.HttpPostAsync(command, tuner, options, cancellationToken).ConfigureAwait(false);
			var deserialize = Deserialize<Response>(textStream);
			response = deserialize as Response;
			return response;
		}

		public async Task<ResponseObject<T, R>> GetResponseObjectAsync<T, R>(R request_object, TunerHostInfo tuner, TvMosaicProviderOptions options, CancellationToken cancellationToken, bool includeResponse = true, bool includeRequest = true)
			where T : class
			where R : class, IRequest
		{
			object responseObject;
			Response response;
			var responseObjectValue = new ResponseObject<T, R>();

			response = await this.GetResponseAsync<R>(request_object, tuner, options, cancellationToken).ConfigureAwait(false);
			if (includeResponse)
			{
				responseObjectValue.Response = response;
			}

			if (includeRequest)
			{
				responseObjectValue.Request = request_object;
			}

			string responseString = this.CheckXmlString(response.Result);
			responseObjectValue.Status = response.Status;

			if (EnumStatusCode.STATUS_OK == (EnumStatusCode)response.Status)
			{
				if (!(request_object is Response))
				{
					responseObject = (object)Deserialize<T>(responseString);
				}
				else
				{
					responseObject = (object)null;
				}
			}
			else
			{
				return responseObjectValue;
			}


			responseObjectValue.ResultObject = (T)responseObject;
			return responseObjectValue;
		}

		/// <summary> HTTP post asynchronous. </summary>
		/// <param name="postParameters"> Options for controlling the post. </param>
		/// <param name="cancellationToken"> The cancellation token. </param>
		/// <returns> The asynchronous result that yields a string. </returns>
		public abstract Task<string> HttpPostAsync(Dictionary<string, string> postParameters, TunerHostInfo tuner, TvMosaicProviderOptions options, CancellationToken cancellationToken);

		/// <summary>
		/// Serialize this TSoft.TVServer.HttpClientBase to the given stream. </summary>
		/// <typeparam name="TValueType"> Type of the value type. </typeparam>
		/// <param name="data"> The data. </param>
		/// <returns> A string. </returns>
		public string Serialize<TValueType>(TValueType data)
		{
			using (var writer = new StringWriter())
			{
				var serializer = this.GetSerializer(typeof(TValueType));
				serializer.Serialize(writer, data);

				return writer.ToString();
			}
		}

		/// <summary> Check XML string. </summary>
		/// <param name="xml"> The XML. </param>
		/// <returns> A string. </returns>
		private string CheckXmlString(string xml)
		{
			if (string.IsNullOrEmpty(xml))
			{
				return string.Empty;
			}

			string xmlReturn = string.Empty;
			var xmlDoc = new XmlDocument();
			//DVBLink 4.6 channel correction
			if (xml.StartsWith("?", StringComparison.Ordinal) || xml.StartsWith("?<", StringComparison.Ordinal) || (xml.Length > 0 && xml[0] == '?'))
			{
				xmlReturn = xml.Remove(0, 1);
				this._Logger.Info(xml);
			}
			else
			{
				xmlReturn = xml;
			}

			xmlDoc.LoadXml(xmlReturn);
			return xmlReturn;
		}

		/// <summary> Gets HTTP header dictionary. </summary>
		/// <param name="command"> The command. </param>
		/// <param name="param"> The parameter. </param>
		/// <returns> The HTTP header dictionary. </returns>
		private Dictionary<string, string> GetHttpHeaderDictionary(string command, string param)
		{
            var postData = new Dictionary<string, string>
            {
                { "command", command },
                { "xml_param", param }
            };

            return postData;
		}

		/// <summary> Gets a serializer. </summary>
		/// <param name="type"> The type. </param>
		/// <returns> The serializer. </returns>
		private XmlSerializer GetSerializer(Type type)
		{
			var key = type.FullName;
			XmlSerializer xmlSerializer = new XmlSerializer(type);
			return this._Serializers.GetOrAdd(key, k => xmlSerializer);
		}
	}
}
