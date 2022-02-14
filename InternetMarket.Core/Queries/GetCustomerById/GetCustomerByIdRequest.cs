using InternetMarket.Core.Common.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket.Core.Queries.GetCustomerById
{
    public class GetCustomerByIdRequest : IRequest<CustomerContract>
    {
        public string CustomerId { get; private set; }
        public GetCustomerByIdRequest(string customerId)
        {
            CustomerId = customerId;
        }
    }
}
