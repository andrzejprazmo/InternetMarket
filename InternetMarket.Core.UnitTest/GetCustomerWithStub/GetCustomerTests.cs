using InternetMarket.Core.Common.Contracts;
using InternetMarket.Core.Common.Interfaces;
using InternetMarket.Core.Queries.GetCustomer;
using InternetMarket.Domain.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket.Core.UnitTest.GetCustomerWithStub
{
	public class GetCustomerTests
	{
		[Test]
		public async Task GetCustomer_MappingTest()
		{
			// Arrange


			var sut = new GetCustomerHandler(new CustomerRepositoryStub());
			var customerId = "TEST";

			// Act
			CustomerContract result = await sut.Handle(new GetCustomerRequest(customerId), new System.Threading.CancellationToken(false));

			// Assert
			Assert.True(result.Id == customerId);
			Assert.NotNull(result.Address);
			Assert.NotNull(result.City);
			Assert.NotNull(result.CompanyName);
			Assert.NotNull(result.ContactName);
			Assert.NotNull(result.ContactTitle);
			Assert.NotNull(result.Country);
			Assert.NotNull(result.Fax);
			Assert.NotNull(result.Phone);
			Assert.NotNull(result.PostalCode);
		}
	}


	public class CustomerRepositoryStub : ICustomerRepository
	{
		public Task<string> CreateCustomer(Customer customer)
		{
			throw new NotImplementedException();
		}

		public Task<Customer> GetCustomerById(string customerId)
		{
			return Task.FromResult(new Customer
			{
				Id = "TEST",
				Address = "Address",
				City = "City",
				CompanyName = "CompanyName",
				ContactName = "ContactName",
				ContactTitle = "ContactTitle",
				Country = "Country",
				Fax = "Fax",
				Phone = "Phone",
				PostalCode = "PostalCode"
			});
		}

		public Task<bool> IsCustomerExists(string customerId)
		{
			throw new NotImplementedException();
		}
	}
}
