using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSoft.TVServer.Helpers
{
	/// <summary> A date time extensions. </summary>
	public static class DateTimeExtensions
	{
		/// <summary> The unix epoch. </summary>
		private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
		/// <summary> The unix epoch offset. </summary>
		private static readonly DateTimeOffset UnixEpochOffset = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

		/// <summary> A long extension method that date time from unix timestamp offset seconds. </summary>
		/// <param name="seconds"> The seconds. </param>
		/// <returns> A DateTimeOffset. </returns>
		public static DateTimeOffset DateTimeFromUnixTimestampOffsetSeconds(this long seconds)
		{
			return UnixEpochOffset.AddSeconds(seconds);
		}

		/// <summary> A DateTimeOffset extension method that gets current unix timestamp offset seconds. </summary>
		/// <param name="date"> The date Date/Time. </param>
		/// <returns> The current unix timestamp offset seconds. </returns>
		public static long GetCurrentUnixTimestampOffsetSeconds(this DateTimeOffset date)
		{
			return (long)(date - UnixEpochOffset).TotalSeconds;
		}
	}
}
