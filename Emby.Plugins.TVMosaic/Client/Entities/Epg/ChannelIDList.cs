using System;
using System.Net;
using System.Collections.Generic;

using System.Xml.Serialization;
using System.ComponentModel;

namespace TSoft.TVServer.Entities
{
	/// <summary> List of channel identifiers. </summary>
	[XmlRoot("channels_ids")]
	public class ChannelIDList
	{
		#region [Constructors]

		/// <summary>
		/// Initializes a new instance of the
		/// MediaBrowser.Plugins.DVBLink.Models.ChannelIDList class. </summary>
		/// <param name="id"> The identifier. </param>
		public ChannelIDList(string id)
		{
			this.Items.Add(id);
		}

		/// <summary>
		/// Initializes a new instance of the
		/// MediaBrowser.Plugins.DVBLink.Models.ChannelIDList class. </summary>
		public ChannelIDList() { }

		/// <summary>
		/// Initializes a new instance of the
		/// MediaBrowser.Plugins.DVBLink.Models.ChannelIDList class. </summary>
		/// <param name="ids"> The identifiers. </param>
		public ChannelIDList(List<string> ids)
		{
			this.Items.AddRange(ids);
		}

		#endregion

		#region [Private Fields]

		/// <summary> The items. </summary>
		private List<string> _Items = new List<string>();

		#endregion

		#region [Public Properties]

		/// <summary> Gets or sets the items. </summary>
		/// <value> The items. </value>
		[XmlElement("channel_id")]
		public List<string> Items
		{
			get
			{
				return _Items ?? (_Items = new List<string>());
			}
			set { _Items = value; }
		}

		#endregion

	}
}
