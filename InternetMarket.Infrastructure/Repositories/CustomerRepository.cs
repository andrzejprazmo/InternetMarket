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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDatabaseConnectionProvider _databaseConnectionProvider;
        public CustomerRepository(IDatabaseConnectionProvider databaseConnectionProvider)
        {
            _databaseConnectionProvider = databaseConnectionProvider;
        }
        public async Task<Customer> GetCustomerById(string customerId)
        {
            using (var connection = _databaseConnectionProvider.GetNorthwindConnection())
            {
                string sqlQuery = @"SELECT TOP (1000) [CustomerID] AS Id
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
                  FROM [dbo].[Customers] WHERE [CustomerID] = @CustomerId";
                return await connection.QuerySingleAsync<Customer>(sqlQuery, new { CustomerId = customerId });
            }
        }
    }
}
