﻿using InternetMarket.Core.Commands.CreateCustomer;
using InternetMarket.Core.Common.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket.Core.UnitTest.CreateCustomer
{
	public class CreateCustomerTests
	{
		private Mock<ICustomerRepository> CustomerRepositoryMock = new Mock<ICustomerRepository>();
		private Mock<ILogger<CreateCustomerHandler>> LoggerMock = new Mock<ILogger<CreateCustomerHandler>>();

		private CreateCustomerHandler CreateSut()
		{
			return new CreateCustomerHandler(CustomerRepositoryMock.Object, LoggerMock.Object);
		}

		private CreateCustomerRequest CreateRequest(string customerId)
		{
			return new CreateCustomerRequest
			{
				Id = customerId,
			};
		}

		[Test]
		public async Task CreateCustomer_InputValid_ReturnsCustomerId()
		{
			// Arrange
			string customerId = "TEST";
			var request = CreateRequest(customerId);
			var sut = CreateSut();

			CustomerRepositoryMock.Setup(m => m.GetCustomerById(customerId)).Returns(Task.FromResult<Domain.Entities.Customer>(null));
			CustomerRepositoryMock.Setup(m => m.CreateCustomer(It.IsAny< Domain.Entities.Customer>())).Returns(Task.FromResult(customerId));

			// Act

			var result = await sut.Handle(request, new System.Threading.CancellationToken(false));

			// Assert
			Assert.False(result.Failed);
			Assert.True(result.Value == customerId);
			CustomerRepositoryMock.Verify(m => m.GetCustomerById(customerId), Times.Once);
		}
	}
}