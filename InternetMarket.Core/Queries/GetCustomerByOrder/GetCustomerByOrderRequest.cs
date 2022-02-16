using InternetMarket.Core.Common.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket.Core.Queries.GetCustomerByOrder
{
	public class GetCustomerByOrderRequest : IRequest<CustomerContract>
	{
		public int OrderId { get; private set; }

		public GetCustomerByOrderRequest(int orderId)
		{
			OrderId = orderId;
		}
	}
}
