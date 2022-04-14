using System;
using System.Net;

using System.Xml.Serialization;
using TSoft.TVServer.Constants;

namespace TSoft.TVServer.Entities
{
	/// <summary> A response. </summary>
	[XmlRoot("response")]
	public class Response
	{
		#region [Public Properties]

		/// <summary> Gets or sets the status. </summary>
		/// <value> The status. </value>
		[XmlElement(ElementName = "status_code")]
		public EnumStatusCode Status { get; set; }

		/// <summary> Gets or sets the result. </summary>
		/// <value> The result. </value>
		[XmlElement(ElementName = "xml_result")]
		public string Result { get; set; }

		/// <summary> Gets or sets the exception. </summary>
		/// <value> The exception. </value>
		[XmlIgnore]
		public Exception Exception { get; set; }

		#endregion

	}
}
