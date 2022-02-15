using InternetMarket.Core.Common.Contracts;
using InternetMarket.Core.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InternetMarket.Core.Queries.GetCustomerOrders
{
    public class GetCustomerOrdersHandler : IRequestHandler<GetCustomerOrdersRequest, CustomerOrdersContract>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        public GetCustomerOrdersHandler(ICustomerRepository customerRepository, IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }

        public async Task<CustomerOrdersContract> Handle(GetCustomerOrdersRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerById(request.CustomerId);
            var orders = await _orderRepository.GetOrdersByCustomer(request.CustomerId);
            return new CustomerOrdersContract
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
                PostalCode = customer.PostalCode,
                Orders = orders.Select(o => new OrderContract
                {
                    Id = o.Id,
                    OrderDate = o.OrderDate,
                    ShipAddress = o.ShipAddress,
                    ShipCity = o.ShipCity,
                    ShipName = o.ShipName,
                }),
            };
        }
    }
}
