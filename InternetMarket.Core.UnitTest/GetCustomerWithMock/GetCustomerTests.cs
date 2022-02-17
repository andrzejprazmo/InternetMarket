using InternetMarket.Core.Common.Contracts;
using InternetMarket.Core.Queries.GetCustomer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using InternetMarket.Core.Common.Interfaces;

namespace InternetMarket.Core.UnitTest.GetCustomerWithMock
{
	public class GetCustomerTests
	{
		[Test]
		public async Task GetCustomer_MappingTest()
		{
			// Arrange
			var customerId = "TEST";

			var customRepositoryMock = new Mock<ICustomerRepository>();
			var expectedResult = new Domain.Entities.Customer
			{
				Id = customerId,
				Address = "Address",
				City = "City",
				CompanyName = "CompanyName",
				ContactName = "ContactName",
				ContactTitle = "ContactTitle",
				Country = "Country",
				Fax = "Fax",
				Phone = "Phone",
				PostalCode = "PostalCode"
			};

			customRepositoryMock.Setup(m => m.GetCustomerById(customerId)).Returns(Task.FromResult(expectedResult));

			var sut = new GetCustomerHandler(customRepositoryMock.Object);

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
}
