// <copyright file="TVServerClient.cs" >
// Copyright (c) 2018 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>27.08.2018</date>
// <summary>Implements the TV server client class</summary>
using System;
using System.Threading;
using System.Threading.Tasks;
using TSoft.TVServer.Constants;
using TSoft.TVServer.Entities;
using TSoft.TVServer.Interfaces;
using MediaBrowser.Model.Logging;
using MediaBrowser.Model.LiveTv;
using Emby.Plugins.TVMosaic;

namespace TSoft.TVServer
{
    /// <summary> A TV server client. </summary>
    /// <seealso cref="T:TSoft.TVServer.ITVServerClient"/>
    public class TVServerClient
    {
        /// <summary> Initializes a new instance of the TSoft.TVServer.TVServerClient class. </summary>
        /// <param name="clientType"> The type of the client. </param>
        public TVServerClient(EnumTVServerClientType clientType, HttpClientBase httpClient, ILogger logger)
        {
            this._Logger = logger;
            this.ClientType = clientType;
            this.Name = this.ClientType == EnumTVServerClientType.TVMosaic ? "TVMosaic" : "DVBLink";
            this.HttpClient = httpClient;
            //this.HttpClient = new DVBLinkHttpClient(this.Logger);
            //this.InitializeHttpClient();
        }

        /// <summary> The logger. </summary>
        private ILogger _Logger;

        /// <summary> The connection error retry. </summary>
        private const int _ConnectionErrorRetry = 4;

        /// <summary> Gets the HTTP client. </summary>
        /// <value> The HTTP client. </value>
        /// <seealso cref="P:TSoft.TVServer.ITVServerClient.HttpClient"/>
        public HttpClientBase HttpClient { get; private set; }

        /// <summary> Gets the identifier of the client. </summary>
        /// <value> The identifier of the client. </value>
        /// <seealso cref="P:TSoft.TVServer.ITVServerClient.ClientId"/>
        public string ClientId
        {
            get { return this.ClientType == EnumTVServerClientType.TVMosaic ? "BD4C3582-AA2E-4C89-B816-F0EEF937CAEE" : "61A0D104-2FC1-473A-8954-CD6AAB1BE0D9"; }
        }

        /// <summary> The logger. </summary>
        /// <value> The logger. </value>
        /// <seealso cref="P:TSoft.TVServer.ITVServerClient.Logger"/>
        public ILogger Logger
        {
            get { return this._Logger; }
        }

        /// <summary> Gets or sets a value indicating whether the debug log. </summary>
        /// <value> true if debug log, false if not. </value>
        /// <seealso cref="P:TSoft.TVServer.ITVServerClient.DebugLog"/>
        public bool DebugLog { get; set; }

        /// <summary> Gets the type of the client. </summary>
        /// <value> The type of the client. </value>
        public EnumTVServerClientType ClientType { get; private set; }

        /// <summary> Gets the name. </summary>
        /// <value> The name. </value>
        public string Name { get; private set; }

        /// <summary> Gets response object asynchronous. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <typeparam name="R"> Type of the r. </typeparam>
        /// <param name="request">			 The request. </param>
        /// <param name="cancellationToken"> A token that allows processing to be cancelled. </param>
        /// <param name="message">			 (Optional) The message. </param>
        /// <param name="checkResultObject"> (Optional) True to check result object. </param>
        /// <returns> An asynchronous result that yields the response object async&lt; t,r&gt; </returns>
        public async Task<T> GetResponseObjectAsync<T, R>(R request, TunerHostInfo tuner, TvMosaicProviderOptions options, CancellationToken cancellationToken, string message = "", bool checkResultObject = true)
            where T : class
            where R : class, IRequest
        {
            if (this.DebugLog)
                this.Logger.Info("Command : {0}", message);
            ResponseObject<T, R> obj = await this.HttpClient.GetResponseObjectAsync<T, R>(request, tuner, options, cancellationToken).ConfigureAwait(false);
            this.CheckResponseObject(obj, checkResultObject);
            return obj.ResultObject;
        }

        /// <summary> Gets response asynchronous. </summary>
        /// <typeparam name="R"> Type of the r. </typeparam>
        /// <param name="request">			 The request. </param>
        /// <param name="cancellationToken"> A token that allows processing to be cancelled. </param>
        /// <param name="message">			 (Optional) The message. </param>
        /// <param name="checkResultObject"> (Optional) True to check result object. </param>
        /// <returns> An asynchronous result that yields the response async&lt; r&gt; </returns>
        public async Task<Response> GetResponseAsync<R>(R request, TunerHostInfo tuner, TvMosaicProviderOptions options, CancellationToken cancellationToken, string message = "", bool checkResultObject = true)
            where R : class, IRequest
        {
            if (this.DebugLog)
                this.Logger.Info("Command : {0}", message);
            var obj = await this.HttpClient.GetResponseAsync<R>(request, tuner, options, cancellationToken).ConfigureAwait(false);
            this.CheckResponse(obj, checkResultObject);
            return obj;
        }

        /// <summary> Check response object. </summary>
        /// <exception cref="NullReferenceException">    Thrown when a value was unexpectedly null. </exception>
        /// <exception cref="InvalidOperationException"> Thrown when the requested operation is invalid. </exception>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="result">			 The result. </param>
        /// <param name="checkResultObject"> (Optional) True to check result object. </param>
        private void CheckResponseObject<T>(ResponseObject<T> result, bool checkResultObject = true) where T : class
        {
            if (result == null)
                throw new NullReferenceException(string.Format("result is null"));

            if (result.Status != EnumStatusCode.STATUS_OK)
                throw new InvalidOperationException(this.FormatDVBLinkStatusError(result.Status), result.Exception);

            if (checkResultObject == true && result.ResultObject == null)
                throw new NullReferenceException(string.Format("result object is null"));
        }

        /// <summary> Check response. </summary>
        /// <exception cref="NullReferenceException">    Thrown when a value was unexpectedly null. </exception>
        /// <exception cref="InvalidOperationException"> Thrown when the requested operation is invalid. </exception>
        /// <param name="result">			 The result. </param>
        /// <param name="checkResultObject"> (Optional) True to check result object. </param>
        private void CheckResponse(Response result, bool checkResultObject = true)
        {
            if (result == null)
                throw new NullReferenceException(string.Format("result is null"));

            if (result.Status != EnumStatusCode.STATUS_OK)
                throw new InvalidOperationException(this.FormatDVBLinkStatusError(result.Status), result.Exception);
        }

        /// <summary> Format dvb link status error. </summary>
        /// <param name="statusCode"> The status code. </param>
        /// <returns> The formatted dvb link status error. </returns>
        private string FormatDVBLinkStatusError(EnumStatusCode statusCode)
        {
            return string.Format("Server Status : {0}", statusCode.ToString());
        }

        /// <summary> Gets direct channel stream. </summary>
        /// <param name="clientId">  Identifier for the client. </param>
        /// <param name="channelId"> Identifier for the channel. </param>
        /// <returns> The direct channel stream. </returns>
        public string GetDirectChannelStream(TunerHostInfo tuner, TvMosaicProviderOptions options, string clientId, string channelId)
        {
            var url = tuner.Url;

            if (Uri.TryCreate(url, UriKind.Absolute, out Uri uri))
            {
                var builder = new UriBuilder(uri);

                builder.Port = options.StreamingPort;

                // make sure it has a trailing /
                url = builder.Uri.ToString().TrimEnd('/') + "/";
            }

            var urlbind = options.Version > 6 ? "stream" : "dvblink";

            url += "/" + urlbind + "/direct?";

            url += $"client={clientId}";
            url += $"&channel={channelId}";
            return url;
        }

        /// <summary> Gets channels asynchronous. </summary>
        /// <param name="cancellationToken"> A token that allows processing to be cancelled. </param>
        /// <returns> An asynchronous result that yields the channels. </returns>
        public Task<Channels> GetChannelsAsync(TunerHostInfo tuner, TvMosaicProviderOptions options, CancellationToken cancellationToken)
        {
            return this.GetResponseObjectAsync<Channels, ChannelsRequest>(new ChannelsRequest(), tuner, options, cancellationToken, "Get Channels");
        }

        /// <summary> Updates the channels. </summary>
        /// <param name="channels"> The channels. </param>
        /// <param name="logoPath"> Full pathname of the logo file. </param>
        /// <returns> The Channels. </returns>
        public Channels UpdateChannels(Channels channels)
        {
            this.Logger.Info("Get Logos from server");

            foreach (var channel in channels.Items)
            {
                var imagePath = channel.ChannelLogo;
                channel.ServerLogo = true;
                channel.IsHD = channel.Name.IndexOf("hd", StringComparison.OrdinalIgnoreCase) >= 0;
                channel.ChannelLogo = imagePath;
                channel.HasChannelLogo = !string.IsNullOrEmpty(channel.ChannelLogo);
            }

            return channels;
        }

        /// <summary> Gets epg asynchronous. </summary>
        /// <param name="request">			 The request. </param>
        /// <param name="cancellationToken"> A token that allows processing to be cancelled. </param>
        /// <returns> An asynchronous result that yields the epg. </returns>
        public Task<EpgSearcher> GetEpgAsync(EpgRequest request, TunerHostInfo tuner, TvMosaicProviderOptions options, CancellationToken cancellationToken)
        {
            return this.GetResponseObjectAsync<EpgSearcher, EpgRequest>(request, tuner, options, cancellationToken, "Get Epg");
        }
    }
}
