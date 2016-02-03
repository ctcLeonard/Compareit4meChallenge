using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3
{
	public class PhoneNumber
	{
		public int CountryCode { get; set; }
		public int AreaCode { get; set; }
		public int Number { get; set; }

		/// <summary>
		/// Parses a phone number in the format XXX XX XXXXXXX
		/// </summary>
		/// <param name="raw">The raw string to parse</param>
		/// <returns>The parsed Phonenumber</returns>
		public static PhoneNumber Parse(string raw)
		{
			string[] parts = raw.Split(new char[] { ' ' });

			return new PhoneNumber() { CountryCode = raw[0], AreaCode = raw[1], Number = raw[2] };
		}
	}
}
