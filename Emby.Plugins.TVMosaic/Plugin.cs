// <copyright file="Plugin.cs" >
// Copyright (c) 2017 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares André</author>
// <date>01.09.2017</date>
// <summary>Implements the TVMosaic plugin class</summary>
using System;
using System.Collections.Generic;
using Emby.Plugins.DVBLogic.Proxies;
using TSoft.TVServer.Helpers;
using MediaBrowser.Model.Logging;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Serialization;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Net;
using MediaBrowser.Model.Drawing;
using System.IO;
using System.Linq;

namespace Emby.Plugins.TVMosaic
{
	/// <summary> A plugin. </summary>
	/// <seealso cref="T:MediaBrowser.Common.Plugins.BasePlugin{Emby.Plugins.DVBLink.Configuration.PluginConfiguration}"/>
	/// <seealso cref="T:MediaBrowser.Model.Plugins.IHasWebPages"/>
	public class Plugin : BasePlugin, IHasWebPages, IHasThumbImage, IHasTranslations
    {
		/// <summary> Initializes a new instance of the Emby.Plugins.TVMosaic.Plugin class. </summary>
		/// <param name="applicationPaths"> The application paths. </param>
		/// <param name="xmlSerializer">    The XML serializer. </param>
		/// <param name="logger">		    The logger. </param>
		/// <param name="httpClient">	    The HTTP client. </param>
		public Plugin(IXmlSerializer xmlSerializer, ILogManager logManager, IHttpClient httpClient)
			: base()
		{
			Instance = this;
			this.Logger = logManager.GetLogger(StaticName);
		}

		/// <summary> The identifier. </summary>
		private Guid _Id = new Guid("864e544d-051b-4b4c-aeec-20d42773c796");

		/// <summary> Gets the instance. </summary>
		/// <value> The instance. </value>
		public static Plugin Instance { get; private set; }

		/// <summary> Gets or sets the logger. </summary>
		/// <value> The logger. </value>
		public ILogger Logger { get; }

		/// <summary> Gets the description. </summary>
		/// <value> The description. </value>
		public override string Description
		{
			get { return "Provides live tv using TVMosaic."; }
		}

		/// <summary> Gets the identifier. </summary>
		/// <value> The identifier. </value>
		public override Guid Id
		{
			get { return this._Id; }
		}

		public static string StaticName = "TVMosaic";

		/// <summary> Gets the name. </summary>
		/// <value> The name. </value>
		public override string Name
		{
			get { return StaticName; }
		}

        /// <summary> Gets thumb image. </summary>
        /// <returns> The thumb image. </returns>
        public Stream GetThumbImage()
        {
            var type = GetType();
            return type.Assembly.GetManifestResourceStream(type.Namespace + ".thumb.png");
        }

        /// <summary> Gets the thumb image format. </summary>
        /// <value> The thumb image format. </value>
        public ImageFormat ThumbImageFormat
        {
            get
            {
                return ImageFormat.Png;
            }
        }

		public IEnumerable<PluginPageInfo> GetPages()
		{
			return new PluginPageInfo[]
			{
				new PluginPageInfo
				{
					Name = "tvmosaic",
					EmbeddedResourcePath = GetType().Namespace + ".web.tvmosaic.html",
					IsMainConfigPage = false
				},
				new PluginPageInfo
				{
					Name = "tvmosaicjs",
					EmbeddedResourcePath = GetType().Namespace + ".web.tvmosaic.js"
				}
			};
		}

		public TranslationInfo[] GetTranslations()
		{
			var basePath = GetType().Namespace + ".strings.";

			return GetType()
				.Assembly
				.GetManifestResourceNames()
				.Where(i => i.StartsWith(basePath, StringComparison.OrdinalIgnoreCase))
				.Select(i => new TranslationInfo
				{
					Locale = Path.GetFileNameWithoutExtension(i.Substring(basePath.Length)),
					EmbeddedResourcePath = i

				}).ToArray();
		}
	}
}
