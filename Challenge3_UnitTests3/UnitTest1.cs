using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Challenge3;
using System.Collections.Generic;

namespace Challenge3_UnitTests3
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestGetAllPhoneNumbers()
		{
			IRepository customerRepo = new CustomerRepository();

			Assert.AreEqual(2, customerRepo.GetAllPhoneNumbers().Count);
		}

		[TestMethod]
		public void TestGetAllPhoneNumbersFromCustomer()
		{
			IRepository customerRepo = new CustomerRepository();

			PhoneNumber control = new PhoneNumber()
			{
				CountryCode = 971,
				AreaCode = 56,
				Number = 1111111
			};

			PhoneNumber actual = customerRepo.GetPhoneNumberByID(1)[0];

			Assert.AreEqual(control.CountryCode, actual.CountryCode);
			Assert.AreEqual(control.AreaCode, actual.AreaCode);
			Assert.AreEqual(control.Number, actual.Number);
		}

		[TestMethod]
		public void TestActivatePhoneNumber()
		{
			IRepository customerRepo = new CustomerRepository();

			customerRepo.ActivatePhoneNumber(new PhoneNumber() { AreaCode = 11, CountryCode = 111, Number = 1234567 }, 2);

			PhoneNumber control = new PhoneNumber()
			{
				CountryCode = 111,
				AreaCode = 11,
				Number = 1234567
			};

			List<PhoneNumber> numbers = customerRepo.GetPhoneNumberByID(2);

			//Get the last entry
			PhoneNumber actual = numbers[numbers.Count - 1];

			Assert.AreEqual(control.CountryCode, actual.CountryCode);
			Assert.AreEqual(control.AreaCode, actual.AreaCode);
			Assert.AreEqual(control.Number, actual.Number);
		}
	}
}
