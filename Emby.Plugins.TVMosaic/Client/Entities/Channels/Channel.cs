using System;
using System.Net;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.ComponentModel;
using TSoft.TVServer.Constants;

namespace TSoft.TVServer.Entities
{
    /// <summary> A channel. </summary>
	[XmlRoot("channel")]
    public class Channel
    {
        #region [Public Properties]

        /// <summary> Gets or sets the identifier of the channel. </summary>
        /// <value> The identifier of the channel. </value>
        [XmlElement(ElementName = "channel_id")]
        public string ChannelID { get; set; }

        /// <summary> Gets or sets the identifier of the channel dvb link. </summary>
        /// <value> The identifier of the channel dvb link. </value>
		[XmlElement(ElementName = "channel_dvblink_id")]
        public string ChannelDVBLinkID { get; set; }

        /// <summary> Gets or sets the name. </summary>
        /// <value> The name. </value>
		[XmlElement(ElementName = "channel_name")]
        public string Name { get; set; }

        /// <summary> Gets or sets the number of. </summary>
        /// <value> The number. </value>
		[XmlElement(ElementName = "channel_number")]
        public int Number { get; set; }

        /// <summary> Gets or sets the subnumber. </summary>
        /// <value> The subnumber. </value>
		[XmlElement(ElementName = "channel_subnumber"), DefaultValue(0)]
        public int Subnumber { get; set; }

        /// <summary> Gets or sets the type. </summary>
        /// <value> The type. </value>
		[XmlElement(ElementName = "channel_type")]
        public EnumChannelType Type { get; set; }

        /// <summary> Gets or sets a value indicating whether the child is locked. </summary>
        /// <value> true if child lock, false if not. </value>
		[XmlElement(ElementName = "channel_child_lock"), DefaultValue(false)]
        public bool ChildLock { get; set; }

        /// <summary> Gets or sets the channel logo. </summary>
        /// <value> The channel logo. </value>
        [XmlElement(ElementName = "channel_logo")]
        public string ChannelLogo { get; set; }

		/// <summary> Gets or sets the channel encrypted. </summary>
		/// <value> The channel encrypted. </value>
		[XmlElement(ElementName = "channel_encrypted")]
		public int ChannelEncrypted { get; set; }

		/// <summary> Gets or sets the channel comment. </summary>
		/// <value> The channel comment. </value>
		[XmlElement(ElementName = "channel_comment")]
		public string ChannelComment { get; set; }

        /// <summary> Gets or sets a value indicating whether this Channel has channel logo. </summary>
        /// <value> True if this Channel has channel logo, false if not. </value>
		[XmlIgnore]
        public bool HasChannelLogo { get; set; }

        /// <summary> Gets or sets a value indicating whether the server logo. </summary>
        /// <value> True if server logo, false if not. </value>
        [XmlIgnore]
        public bool ServerLogo { get; set; }

        /// <summary> Gets or sets a value indicating whether this Channel is HD. </summary>
        /// <value> True if this Channel is hd, false if not. </value>
        [XmlIgnore]
        public bool IsHD { get; set; }
        #endregion

    }
}
