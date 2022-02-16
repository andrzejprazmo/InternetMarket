using InternetMarket.Core.Common.Contracts;
using InternetMarket.Core.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InternetMarket.Core.Queries.GetCustomer
{
    public class GetCustomerHandler : IRequestHandler<GetCustomerRequest, CustomerContract>
    {
        private readonly ICustomerRepository _customerRepository;
        public GetCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<CustomerContract> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerById(request.CustomerId);
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
