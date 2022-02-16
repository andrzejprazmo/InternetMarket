using Dapper;
using InternetMarket.Core.Common.Interfaces;
using InternetMarket.Domain.Entities;
using InternetMarket.Infrastructure.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDatabaseConnectionProvider _databaseConnectionProvider;

        public OrderRepository(IDatabaseConnectionProvider databaseConnectionProvider)
        {
            _databaseConnectionProvider = databaseConnectionProvider;
        }

		public async Task<IEnumerable<Order>> GetOrdersByCustomer(string customerId)
        {
            using (var connection = _databaseConnectionProvider.GetNorthwindConnection())
            {
                string sqlQuery = @"SELECT TOP (1000) [OrderID] AS Id
                      ,[OrderDate]
                      ,[ShipName]
                      ,[ShipAddress]
                      ,[ShipCity]
                  FROM [dbo].[Orders] WHERE [CustomerID] = @CustomerId";
                return await connection.QueryAsync<Order>(sqlQuery, new { CustomerId = customerId });
            }
        }

        public async Task<Customer> GetCustomerByOrder(int orderId)
        {
            using (var connection = _databaseConnectionProvider.GetNorthwindConnection())
            {
                string sqlQuery = @"SELECT TOP (1) [dbo].[Orders].[CustomerID] AS Id
                      ,[CompanyName]
                      ,[ContactName]
                      ,[ContactTitle]
                      ,[Address]
                      ,[City]
                      ,[Region]
                      ,[PostalCode]
                      ,[Country]
                      ,[Phone]
                      ,[Fax]
                  FROM [dbo].[Customers]
                  JOIN [dbo].[Orders] ON [dbo].[Customers].CustomerID = [dbo].[Orders].CustomerID
                  WHERE [dbo].[Orders].OrderID = @OrderId";
                return await connection.QuerySingleAsync<Customer>(sqlQuery, new { OrderId = orderId });
            }
        }
    }
}
