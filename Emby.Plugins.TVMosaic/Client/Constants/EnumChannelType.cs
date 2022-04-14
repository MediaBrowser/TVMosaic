using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TSoft.TVServer.Constants
{
	/// <summary> Values that represent enumeration channel types. </summary>
	public enum EnumChannelType
	{
		/// <summary> An enum constant representing the rd channel TV option. </summary>
		[XmlEnum("0")]
		RD_CHANNEL_TV = 0,

		/// <summary> An enum constant representing the rd channel radio option. </summary>
		[XmlEnum("1")]
		RD_CHANNEL_RADIO = 1,

		/// <summary> An enum constant representing the rd channel other option. </summary>
		[XmlEnum("2")]
		RD_CHANNEL_OTHER = 2
	}
}
