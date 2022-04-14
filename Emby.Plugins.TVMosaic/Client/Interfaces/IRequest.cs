using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TSoft.TVServer.Interfaces
{
	/// <summary> A request. </summary>
	public interface IRequest
	{
		#region [Properties Implementation]

		/// <summary> Gets the HTTP command. </summary>
		/// <value> The HTTP command. </value>
		string HttpCommand { get; }
		#endregion
	}
}
