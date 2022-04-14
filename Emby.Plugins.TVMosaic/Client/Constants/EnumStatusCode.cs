using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TSoft.TVServer.Constants
{
    /// <summary> Values that represent enumeration status codes. </summary>
	public enum EnumStatusCode
	{
        /// <summary> An enum constant representing the status none option. </summary>
		[XmlEnum("-1")]
		STATUS_NONE = -1,

		/// <summary> An enum constant representing the status ok option. </summary>
		[XmlEnum("0")]
		STATUS_OK = 0,

		/// <summary> An enum constant representing the status error option. </summary>
		[XmlEnum("1000")]
		STATUS_ERROR = 1000,

		/// <summary> An enum constant representing the status invalid data option. </summary>
		[XmlEnum("1001")]
		STATUS_INVALID_DATA = 1001,

		/// <summary> An enum constant representing the status invalid parameter option. </summary>
		[XmlEnum("1002")]
		STATUS_INVALID_PARAM = 1002,

		/// <summary> An enum constant representing the status not implemented option. </summary>
		[XmlEnum("1003")]
		STATUS_NOT_IMPLEMENTED = 1003,

		/// <summary> An enum constant representing the status mc not running option. </summary>
		[XmlEnum("1005")]
		STATUS_MC_NOT_RUNNING = 1005,

		/// <summary> An enum constant representing the status no default recorder option. </summary>
		[XmlEnum("1006")]
		STATUS_NO_DEFAULT_RECORDER = 1006,

		/// <summary> An enum constant representing the status mce connection error option. </summary>
		[XmlEnum("1008")]
		STATUS_MCE_CONNECTION_ERROR = 1008,

		/// <summary> An enum constant representing the status not activated= option. </summary>
		[XmlEnum("1012")]
		STATUS_NOT_ACTIVATED= 1012,

		/// <summary> An enum constant representing the status no free tuner option. </summary>
		[XmlEnum("1013")]
		STATUS_NO_FREE_TUNER = 1013,

		/// <summary> An enum constant representing the status connection error option. </summary>
		[XmlEnum("2000")]
		STATUS_CONNECTION_ERROR = 2000,

		/// <summary> An enum constant representing the status unauthorised option. </summary>
		[XmlEnum("2001")]
		STATUS_INVALID_STATE = 2001,

		/// <summary> An enum constant representing the status not authorized option. </summary>
		[XmlEnum("2002")]
		STATUS_NOT_AUTHORIZED = 2002
	}
}
