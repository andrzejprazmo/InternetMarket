using InternetMarket.Core.Common.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket.Core.Queries.GetCustomerOrders
{
    public class GetCustomerOrdersRequest : IRequest<CustomerOrdersContract>
    {
        public string CustomerId { get; private set; }
        public GetCustomerOrdersRequest(string customerId)
        {
            CustomerId = customerId;
        }
    }
}
