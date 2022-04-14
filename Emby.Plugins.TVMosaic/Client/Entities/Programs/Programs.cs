using System;
using System.Net;

using System.Collections.Generic;
using System.Xml.Serialization;
using System.ComponentModel;

namespace TSoft.TVServer.Entities
{
	/// <summary> A programs. </summary>
	[XmlRoot("dvblink_epg")]
	public class Programs
	{
        #region [Public Properties]

        /// <summary> Gets or sets the items. </summary>
        /// <value> The items. </value>
        [XmlElement("program")]
        public List<Program> Items { get; set; } = new List<Program>();

        #endregion

    }
}
