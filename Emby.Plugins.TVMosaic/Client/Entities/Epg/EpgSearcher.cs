using System;
using System.Net;
using System.Collections.Generic;

using System.Xml.Serialization;
using System.ComponentModel;

namespace TSoft.TVServer.Entities
{
    /// <summary> An epg searcher. </summary>
	[XmlRoot("epg_searcher")]
	public class EpgSearcher
	{
        #region [Public Properties]

        /// <summary> Gets or sets the items. </summary>
        /// <value> The items. </value>
        [XmlElement("channel_epg")]
        public List<EpgChannel> Items { get; set; } = new List<EpgChannel>();

        #endregion

    }
}
