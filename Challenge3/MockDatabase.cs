using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3
{
	public class MockDatabase
	{
		private List<Customer> Customers;

		private void Init()
		{
			Customers = new List<Customer>();
			Customers.Add(new Customer()
			{
				ID = 1,
				Name = "John Doe",
				Phonenumbers = new List<PhoneNumber>()
				{
					new PhoneNumber()
					{
						CountryCode = 971,
						AreaCode = 56,
						Number = 1111111
					}
				}
			});

			Customers.Add(new Customer()
			{
				ID = 2,
				Name = "Jane Doe",
				Phonenumbers = new List<PhoneNumber>()
				{
					new PhoneNumber()
					{
						CountryCode = 971,
						AreaCode = 56,
						Number = 2222222
					}
				}
			});
		}

		/// <summary>
		/// Acts as a mock database
		/// </summary>
		internal void Connect()
		{
			if (Customers == null)
				Init();
		}

		/// <summary>
		/// Closes the database and commits any pending changes
		/// </summary>
		internal void Close()
		{
			//This is where a real implentention could close and save the database state.
		}

		/// <summary>
		/// Gets all the phone numbers from the database
		/// </summary>
		/// <returns></returns>
		internal List<PhoneNumber> GetAllPhoneNumbers()
		{
			//Mock DB Code
			List<PhoneNumber> result = new List<PhoneNumber>();
			foreach (Customer cust in Customers)
			{
				result.AddRange(cust.Phonenumbers);
			}

			//How a real implementation could look

			//using (SqlConnection connection = new SqlConnection(_connectionString))
			//{
			//	SqlCommand command = new SqlCommand("GetPhoneNumbers", connection);
			//	command.CommandType = CommandType.StoredProcedure;
			//	command.Connection.Open();
			//	using (SqlDataReader reader = command.ExecuteReader())
			//	{
			//		while (reader.Read())
			//		{
			//			string rawPhoneNumber = reader.GetString(0);
			//			result.Add(PhoneNumber.Parse(rawPhoneNumber));
			//		}
			//	}
			//}

			return result;
		}

		/// <summary>
		/// Gets all the phone numbers from a single customer by id.
		/// </summary>
		internal List<PhoneNumber> GetPhoneNumberByID(int id)
		{
			//Mock DB Code
			List<PhoneNumber> result = new List<PhoneNumber>();
			result = Customers.First(c => c.ID == id).Phonenumbers;

			//How a real implementation could look

			//using (SqlConnection connection = new SqlConnection(_connectionString))
			//{
			//	SqlCommand command = new SqlCommand("GetPhonesByID", connection);
			//	command.CommandType = CommandType.StoredProcedure;
			//	command.Parameters.Add(new SqlParameter("@id", id));
			//	command.Connection.Open();
			//	using (SqlDataReader reader = command.ExecuteReader())
			//	{
			//		while (reader.Read())
			//		{
			//			string rawPhoneNumber = reader.GetString(0);
			//			result.Add(PhoneNumber.Parse(rawPhoneNumber));
			//		}
			//	}
			//}

			return result;
		}

		/// <summary>
		/// Gets all the phone numbers from a customer by name.
		/// </summary>
		internal List<PhoneNumber> GetPhoneNumberByName(string name)
		{
			//Mock DB Code
			List<PhoneNumber> result = new List<PhoneNumber>();
			result = Customers.First(c => c.Name == name).Phonenumbers;

			//How a real implementation could look

			//using (SqlConnection connection = new SqlConnection(_connectionString))
			//{
			//	SqlCommand command = new SqlCommand("GetPhonesByName", connection);
			//	command.CommandType = CommandType.StoredProcedure;
			//	command.Parameters.Add(new SqlParameter("@name", name));
			//	command.Connection.Open();
			//	using (SqlDataReader reader = command.ExecuteReader())
			//	{
			//		while (reader.Read())
			//		{
			//			string rawPhoneNumber = reader.GetString(0);
			//			result.Add(PhoneNumber.Parse(rawPhoneNumber));
			//		}
			//	}
			//}

			return result;
		}

		/// <summary>
		/// Retrieves a customer by its name
		/// </summary>
		internal Customer GetCustomer(string name)
		{
			Customer customer;
			//Mock DB Code
			customer = Customers.First(c => c.Name == name);

			//How a real implementation could look

			//using (SqlConnection connection = new SqlConnection(_connectionString))
			//{
			//	SqlCommand command = new SqlCommand("GetCustomerByName", connection);
			//	command.CommandType = CommandType.StoredProcedure;
			//	command.Parameters.Add(new SqlParameter("@name", name));
			//	command.Connection.Open();
			//	using (SqlDataReader reader = command.ExecuteReader())
			//	{
			//		while (reader.Read())
			//		{
			//			customer = new Customer() { ID = reader.GetInt32(0), Name = reader.GetString(1) };
			//		}
			//	}
			//}

			////Retrieve the phone numbers using our previous methods. No need to make extra code
			//customer.Phonenumbers = GetPhoneNumberByName(name);

			return customer;
		}

		/// <summary>
		/// Retrieves a customer by its ID
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		internal Customer GetCustomer(int id)
		{
			Customer customer;
			//Mock DB Code
			customer = Customers.First(c => c.ID == id);

			//How a real implementation could look

			//using (SqlConnection connection = new SqlConnection(_connectionString))
			//{
			//	SqlCommand command = new SqlCommand("GetCustomerByID", connection);
			//	command.CommandType = CommandType.StoredProcedure;
			//	command.Parameters.Add(new SqlParameter("@id", id));
			//	command.Connection.Open();
			//	using (SqlDataReader reader = command.ExecuteReader())
			//	{
			//		while (reader.Read())
			//		{
			//			customer = new Customer() { ID = reader.GetInt32(0), Name = reader.GetString(1) };
			//		}
			//	}
			//}

			////Retrieve the phone numbers using our previous methods. No need to make extra code
			//customer.Phonenumbers = GetPhoneNumberByID(id);

			return customer;
		}

		/// <summary>
		/// Adds a new phone number to the given customer
		/// </summary>
		internal void ActivatePhoneNumber(PhoneNumber phone, Customer customer)
		{
			//Mock DB Code
			Customers.First(c => c.ID == customer.ID).Phonenumbers.Add(phone);

			//How a real implementation could look

			//using (SqlConnection connection = new SqlConnection(_connectionString))
			//{
			//	SqlCommand command = new SqlCommand("SaveCustomer", connection);
			//	command.CommandType = CommandType.StoredProcedure;
			//	command.Parameters.Add(new SqlParameter("@name", customer.Name));
			//	command.Parameters.Add(new SqlParameter("@id", customer.ID));
			//	command.Parameters.Add(new SqlParameter("@phonenumbers", customer.Phonenumbers));
			//	command.Connection.Open();
			//	command.ExecuteNonQuery();
			//}
		}
	}
}
