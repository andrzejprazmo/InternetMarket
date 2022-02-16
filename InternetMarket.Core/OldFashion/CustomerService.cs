using InternetMarket.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket.Core.OldFashion
{
	public class CustomerService : ICustomerService
	{
		public Task<CustomerContract> GetCustomer(string customerId)
		{
			throw new NotImplementedException();
		}

		public Task<CustomerContract> GetCustomerByOrder(int orderId)
		{
			throw new NotImplementedException();
		}

		public Task<CustomerOrdersContract> GetCustomerOrders(string customerId)
		{
			throw new NotImplementedException();
		}
	}
}
