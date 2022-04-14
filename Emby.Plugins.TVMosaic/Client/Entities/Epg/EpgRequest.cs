using System;
using System.Net;
using System.Collections.Generic;

using System.Xml.Serialization;
using System.ComponentModel;
using TSoft.TVServer.Interfaces;
using TSoft.TVServer.Constants;

namespace TSoft.TVServer.Entities
{
    /// <summary> An epg request. </summary>
    /// <seealso cref="T:TSoft.TVServer.Interfaces.IRequest"/>
	[XmlRoot("epg_searcher")]
    public class EpgRequest : IRequest
	{
		#region [Constructors]
        /// <summary>
        /// Initializes a new instance of the TSoft.TVServer.Entities.EpgRequest class. </summary>
        /// <param name="start_time"> The start time. </param>
        /// <param name="end_time"> The end time. </param>
        /// <param name="is_epg_short"> true if this TSoft.TVServer.Entities.EpgRequest is epg
        /// short. </param>
		public EpgRequest(long start_time , long end_time , bool is_epg_short = false )
		{
			EpgShort = is_epg_short;
			StartTime = start_time;
			EndTime = end_time;
		}

        /// <summary>
        /// Initializes a new instance of the TSoft.TVServer.Entities.EpgRequest class. </summary>
        /// <param name="channels_ids"> List of identifiers for the channels. </param>
        /// <param name="start_time"> The start time. </param>
        /// <param name="end_time"> The end time. </param>
        /// <param name="is_epg_short"> true if this TSoft.TVServer.Entities.EpgRequest is epg
        /// short. </param>
		public EpgRequest(ChannelIDList channels_ids, long start_time , long end_time , bool is_epg_short = false )
		{
			ChannelsIDs = channels_ids;
			EpgShort = is_epg_short;
			StartTime = start_time;
			EndTime = end_time;
		}

        /// <summary>
        /// Initializes a new instance of the TSoft.TVServer.Entities.EpgRequest class. </summary>
        /// <param name="keywords"> The keywords. </param>
        /// <param name="start_time"> The start time. </param>
        /// <param name="end_time"> The end time. </param>
        /// <param name="is_epg_short"> true if this TSoft.TVServer.Entities.EpgRequest is epg
        /// short. </param>
		public EpgRequest(string keywords, long start_time , long end_time, bool is_epg_short )
		{
			Keywords = keywords;
			EpgShort = is_epg_short;
			StartTime = start_time;
			EndTime = end_time;
		}

        /// <summary>
        /// Initializes a new instance of the TSoft.TVServer.Entities.EpgRequest class. </summary>
        /// <param name="channels_ids"> List of identifiers for the channels. </param>
        /// <param name="keywords"> The keywords. </param>
        /// <param name="start_time"> The start time. </param>
        /// <param name="end_time"> The end time. </param>
        /// <param name="is_epg_short"> true if this TSoft.TVServer.Entities.EpgRequest is epg
        /// short. </param>
		public EpgRequest(ChannelIDList channels_ids, string keywords, long start_time , long end_time , bool is_epg_short = false)
		{
			ChannelsIDs = channels_ids;
			Keywords = keywords;
			EpgShort = is_epg_short;
			StartTime = start_time;
			EndTime = end_time;
		}

        /// <summary>
        /// Initializes a new instance of the TSoft.TVServer.Entities.EpgRequest class. </summary>
		public EpgRequest()
		{
		}

        /// <summary>
        /// Initializes a new instance of the TSoft.TVServer.Entities.EpgRequest class. </summary>
        /// <param name="channel_id"> Identifier for the channel. </param>
		public EpgRequest(string channel_id)
		{
			ChannelsIDs = new ChannelIDList(channel_id);
		}

        /// <summary>
        /// Initializes a new instance of the TSoft.TVServer.Entities.EpgRequest class. </summary>
        /// <param name="channel_id"> Identifier for the channel. </param>
        /// <param name="start_time"> The start time. </param>
        /// <param name="end_time"> The end time. </param>
		public EpgRequest(string channel_id, long start_time, long end_time)
		{
			ChannelsIDs = new ChannelIDList(channel_id);
			StartTime = start_time;
			EndTime = end_time;
		}

        /// <summary>
        /// Initializes a new instance of the TSoft.TVServer.Entities.EpgRequest class. </summary>
        /// <param name="channel_id"> Identifier for the channel. </param>
        /// <param name="program_id"> Identifier for the program. </param>
		public EpgRequest(string channel_id, string program_id)
		{
			ChannelsIDs = new ChannelIDList(channel_id);
			ProgramID = program_id;
		}

		#endregion

		#region [Constants]

        /// <summary> The epg invalid time. </summary>
		public const long EPG_INVALID_TIME = -1;

		#endregion

		#region [Public Properties]
        /// <summary> Gets the HTTP command. </summary>
        /// <value> The HTTP command. </value>
        /// <seealso cref="P:TSoft.TVServer.Interfaces.IRequest.HttpCommand"/>
        public string HttpCommand
        {
            get { return "search_epg"; }
        }

        /// <summary> Gets or sets the channels i ds. </summary>
        /// <value> The channels i ds. </value>
		[XmlElement(ElementName = "channels_ids")]
		public ChannelIDList ChannelsIDs { get; set; }

        /// <summary> Gets or sets the identifier of the program. </summary>
        /// <value> The identifier of the program. </value>
		[XmlElement(ElementName = "program_id"), DefaultValue("")]
		public string ProgramID { get; set; }

        /// <summary> Gets or sets the keywords. </summary>
        /// <value> The keywords. </value>
		[XmlElement(ElementName = "keywords"), DefaultValue("")]
		public string Keywords { get; set; }

        /// <summary> Gets or sets the genre mask. </summary>
        /// <value> The genre mask. </value>
        [XmlElement(ElementName = "genre_mask")]
        public EnumGenreMask? GenreMask { get; set; }

        /// <summary> Gets or sets the number of requested. </summary>
        /// <value> The number of requested. </value>
        [XmlElement(ElementName = "requested_count"), DefaultValue(-1)]
        public long? RequestedCount { get; set; }

        /// <summary> Gets or sets the start time. </summary>
        /// <value> The start time. </value>
        [XmlElement(ElementName = "start_time"), DefaultValue(-1)]
		public long StartTime { get; set; }

        /// <summary> Gets or sets the end time. </summary>
        /// <value> The end time. </value>
		[XmlElement(ElementName = "end_time"), DefaultValue(-1)]
		public long EndTime { get; set; }

        /// <summary> Gets or sets a value indicating whether the epg short. </summary>
        /// <value> true if epg short, false if not. </value>
		[XmlElement(ElementName = "epg_short"), DefaultValue(false)]
		public bool EpgShort { get; set; }

		#endregion

	}
}
