// <copyright file="ChannelHelper.cs" >
// Copyright (c) 2017 Tavares Software Developement. All rights reserved.
// </copyright>
// <author>Tavares André</author>
// <date>01.09.2017</date>
// <summary>Implements the channel helper class</summary>
using MediaBrowser.Model.LiveTv;
using MediaBrowser.Model.MediaInfo;
using TSoft.TVServer.Constants;

namespace Emby.Plugins.DVBLogic.Helpers
{
	/// <summary> A channel helper. </summary>
	public static class ChannelHelper
    {
        /// <summary> Gets channel type. </summary>
        /// <param name="channelType"> Type of the channel. </param>
        /// <returns> The channel type. </returns>
        public static ChannelType GetChannelType(EnumChannelType channelType)
        {
            switch (channelType)
            {
                case EnumChannelType.RD_CHANNEL_TV:
                    return ChannelType.TV;
                case EnumChannelType.RD_CHANNEL_RADIO:
                    return ChannelType.Radio;
                default:
                    return ChannelType.TV;
            }
        }
    }
}
