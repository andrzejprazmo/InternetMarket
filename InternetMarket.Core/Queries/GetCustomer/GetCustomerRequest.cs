using InternetMarket.Core.Common.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket.Core.Queries.GetCustomer
{
    public class GetCustomerRequest : IRequest<CustomerContract>
    {
        public string CustomerId { get; private set; }
        public GetCustomerRequest(string customerId)
        {
            CustomerId = customerId;
        }
    }
}
