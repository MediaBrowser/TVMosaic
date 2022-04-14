using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TSoft.TVServer.Constants
{
	/// <summary> Values that represent enumeration genre masks. </summary>
	[Flags]
	public enum EnumGenreMask
	{
		/// <summary> An enum constant representing the rdgc any option. </summary>
		[XmlEnum("0")]
		RDGC_ANY = 0,

		/// <summary> An enum constant representing the rdgc news option. </summary>
		[XmlEnum("1")]
		RDGC_NEWS = 1,

		/// <summary> An enum constant representing the rdgc kids option. </summary>
		[XmlEnum("2")]
		RDGC_KIDS = 2,

		/// <summary> An enum constant representing the rdgc movie option. </summary>
		[XmlEnum("4")]
		RDGC_MOVIE = 4,

		/// <summary> An enum constant representing the rdgc sport option. </summary>
		[XmlEnum("8")]
		RDGC_SPORT = 8,

		/// <summary> An enum constant representing the rdgc documentary option. </summary>
		[XmlEnum("10")]
		RDGC_DOCUMENTARY = 10,

		/// <summary> An enum constant representing the rdgc action option. </summary>
		[XmlEnum("20")]
		RDGC_ACTION = 20,

		/// <summary> An enum constant representing the rdgc comedy option. </summary>
		[XmlEnum("40")]
		RDGC_COMEDY = 40,

		/// <summary> An enum constant representing the rdgc drama option. </summary>
		[XmlEnum("80")]
		RDGC_DRAMA = 80,

		/// <summary> An enum constant representing the rdgc edu option. </summary>
		[XmlEnum("100")]
		RDGC_EDU = 100,

		/// <summary> An enum constant representing the rdgc horror option. </summary>
		[XmlEnum("200")]
		RDGC_HORROR = 200,

		/// <summary> An enum constant representing the rdgc music option. </summary>
		[XmlEnum("400")]
		RDGC_MUSIC = 400,

		/// <summary> An enum constant representing the rdgc reality option. </summary>
		[XmlEnum("800")]
		RDGC_REALITY = 800,

		/// <summary> An enum constant representing the rdgc romance option. </summary>
		[XmlEnum("1000")]
		RDGC_ROMANCE = 1000,

		/// <summary> An enum constant representing the rdgc scifi option. </summary>
		[XmlEnum("2000")]
		RDGC_SCIFI = 2000,

		/// <summary> An enum constant representing the rdgc serial option. </summary>
		[XmlEnum("4000")]
		RDGC_SERIAL = 4000,

		/// <summary> An enum constant representing the rdgc SOAP option. </summary>
		[XmlEnum("8000")]
		RDGC_SOAP = 8000,

		/// <summary> An enum constant representing the rdgc special option. </summary>
		[XmlEnum("10000")]
		RDGC_SPECIAL = 10000,

		/// <summary> An enum constant representing the rdgc thriller option. </summary>
		[XmlEnum("20000")]
		RDGC_THRILLER = 20000,

		/// <summary> An enum constant representing the rdgc adult option. </summary>
		[XmlEnum("40000")]
		RDGC_ADULT = 40000
	}
}
