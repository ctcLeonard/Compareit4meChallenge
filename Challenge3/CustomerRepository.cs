using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3
{
	/// <summary>
	/// Talks to the database to execute various actions 
	/// </summary>
    public class CustomerRepository : IRepository
    {
		private MockDatabase db;

		public CustomerRepository()
		{
			db = new MockDatabase();
		}

		/// <summary>
		/// Gets all the known phone numbers.
		/// </summary>
		public List<PhoneNumber> GetAllPhoneNumbers()
		{
			db.Connect();
			List<PhoneNumber> phoneNumbers = db.GetAllPhoneNumbers();

			db.Close();

			return phoneNumbers;
		}

		/// <summary>
		/// Gets all the phone numbers that are paired with the given id.
		/// </summary>
		public List<PhoneNumber> GetPhoneNumberByID(int id)
		{
			db.Connect();
			List<PhoneNumber> phoneNumbers = db.GetPhoneNumberByID(id);

			db.Close();

			return phoneNumbers;
		}

		/// <summary>
		/// Gets all the phone numbers that are paired with the given name.
		/// </summary>
		public List<PhoneNumber> GetPhoneNumberByName(string name)
		{
			db.Connect();
			List<PhoneNumber> phoneNumbers = db.GetPhoneNumberByName(name);

			db.Close();

			return phoneNumbers;
		}

		/// <summary>
		/// Activates a new phone number for the given customer name.
		/// </summary>
		/// <param name="rawPhone">the phone number in XXX XX XXXXXXX format</param>
		public void ActivatePhoneNumber(string rawPhone, string name)
		{
			ActivatePhoneNumber(PhoneNumber.Parse(rawPhone), name);
		}

		/// <summary>
		/// Activates a new phone number for the given customer id.
		/// </summary>
		/// <param name="rawPhone">the phone number in XXX XX XXXXXXX format</param>
		public void ActivatePhoneNumber(string rawPhone, int id)
		{
			ActivatePhoneNumber(PhoneNumber.Parse(rawPhone), id);
		}

		/// <summary>
		/// Activates a new phone number for the given customer name.
		/// </summary>
		public void ActivatePhoneNumber(PhoneNumber phone, string name)
		{
			db.Connect();
			db.ActivatePhoneNumber(phone, db.GetCustomer(name));

			db.Close();
		}

		/// <summary>
		/// Activates a new phone number for the given customer id.
		/// </summary>
		public void ActivatePhoneNumber(PhoneNumber phone, int id)
		{
			db.Connect();
			db.ActivatePhoneNumber(phone, db.GetCustomer(id));

			db.Close();
		}
	}
}
