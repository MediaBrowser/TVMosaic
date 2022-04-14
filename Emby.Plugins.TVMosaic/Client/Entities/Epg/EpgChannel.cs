using System;
using System.Net;
using System.Collections.Generic;

using System.Xml.Serialization;
using System.ComponentModel;

namespace TSoft.TVServer.Entities
{
	/// <summary> An epg channel. </summary>
	[XmlRoot("channel_epg")]
	public class EpgChannel
	{
		#region [Public Properties]

		/// <summary> Gets or sets the identifier of the channel. </summary>
		/// <value> The identifier of the channel. </value>
		[XmlElement(ElementName = "channel_id")]
		public string ChannelId { get; set; }

		/// <summary> Gets or sets the programs. </summary>
		/// <value> The programs. </value>
		[XmlElement(ElementName = "dvblink_epg")]
		public Programs Programs { get; set; }

		#endregion

	}
}
