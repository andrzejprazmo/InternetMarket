using InternetMarket.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket.Core.OldFashion
{
	public interface ICustomerService
	{
		Task<CustomerContract> GetCustomer(string customerId);
		Task<CustomerOrdersContract> GetCustomerOrders(string customerId);
		Task<CustomerContract> GetCustomerByOrder(int orderId);
	}
}
