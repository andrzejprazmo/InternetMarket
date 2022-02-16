using InternetMarket.Core.Common.Contracts;
using InternetMarket.Core.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InternetMarket.Core.Queries.GetCustomerByOrder
{
	public class GetCustomerByOrderHandler : IRequestHandler<GetCustomerByOrderRequest, CustomerContract>
	{
		private readonly IOrderRepository _orderRepository;
		public GetCustomerByOrderHandler(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}
		public async Task<CustomerContract> Handle(GetCustomerByOrderRequest request, CancellationToken cancellationToken)
		{
			var customer = await _orderRepository.GetCustomerByOrder(request.OrderId);
			return new CustomerContract
			{
				Id = customer.Id,
				Address = customer.Address,
				City = customer.City,
				CompanyName = customer.CompanyName,
				ContactName = customer.ContactName,
				ContactTitle = customer.ContactTitle,
				Country = customer.Country,
				Fax = customer.Fax,
				Phone = customer.Phone,
				PostalCode = customer.PostalCode
			};
		}
	}
}
