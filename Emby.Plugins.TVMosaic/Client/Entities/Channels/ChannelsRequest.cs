// <copyright file="ChannelsRequest.cs" >
// Copyright (c) 2018 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares</author>
// <date>22.08.2018</date>
// <summary>Implements the channels request class</summary>
using System;
using System.Net;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.ComponentModel;
using TSoft.TVServer.Interfaces;

namespace TSoft.TVServer.Entities
{
	/// <summary> The channels request. </summary>
	/// <seealso cref="T:TSoft.TVServer.Interfaces.IRequest"/>
	[XmlRoot("channels")]
	public class ChannelsRequest : IRequest
	{
		#region [Constructors]
		/// <summary> Initializes a new instance of the TSoft.TVServer.Entities.ChannelsRequest class. </summary>
		public ChannelsRequest()
		{
		}
		#endregion

		#region [Public properties]

		/// <summary> Gets the HTTP command. </summary>
		/// <value> The HTTP command. </value>
		/// <seealso cref="P:TSoft.TVServer.Interfaces.IRequest.HttpCommand"/>
		/// <seealso cref="P:TSoft.TVServer.Constants.IRequest.HttpCommand"/>
		public string HttpCommand
		{
			get { return "get_channels"; }
		}

		#endregion
	}
}
