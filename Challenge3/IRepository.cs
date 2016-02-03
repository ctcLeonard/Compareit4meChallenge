using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3
{
	public interface IRepository
	{
		/// <summary>
		/// Gets all the known phone numbers.
		/// </summary>
		List<PhoneNumber> GetAllPhoneNumbers();

		/// <summary>
		/// Gets all the phone numbers that are paired with the given id.
		/// </summary>
		List<PhoneNumber> GetPhoneNumberByID(int id);

		/// <summary>
		/// Gets all the phone numbers that are paired with the given name.
		/// </summary>
		List<PhoneNumber> GetPhoneNumberByName(string name);

		/// <summary>
		/// Activates a new phone number for the given customer name.
		/// </summary>
		/// <param name="rawPhone">the phone number in XXX XX XXXXXXX format</param>
		void ActivatePhoneNumber(string rawPhone, string name);

		/// <summary>
		/// Activates a new phone number for the given customer id.
		/// </summary>
		/// <param name="rawPhone">the phone number in XXX XX XXXXXXX format</param>
		void ActivatePhoneNumber(string rawPhone, int id);

		/// <summary>
		/// Activates a new phone number for the given customer name.
		/// </summary>
		void ActivatePhoneNumber(PhoneNumber phone, string name);

		/// <summary>
		/// Activates a new phone number for the given customer id.
		/// </summary>
		void ActivatePhoneNumber(PhoneNumber phone, int id);
	}
}
