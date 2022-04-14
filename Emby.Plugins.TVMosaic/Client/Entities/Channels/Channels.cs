using System;
using System.Net;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.ComponentModel;

namespace TSoft.TVServer.Entities
{
    /// <summary> A channels. </summary>
	[XmlRoot("channels")]
	public class Channels
	{
        #region [Public Properties]
        /// <summary> Gets or sets the items. </summary>
        /// <value> The items. </value>
        [XmlElement("channel")]
        public List<Channel> Items { get; set; } = new List<Channel>();

        #endregion

    }
}
