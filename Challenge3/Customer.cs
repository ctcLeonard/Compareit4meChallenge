using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3
{
	public class Customer
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public List<PhoneNumber> Phonenumbers { get; set; }

		public Customer()
		{
			Phonenumbers = new List<PhoneNumber>();
		}
	}
}
