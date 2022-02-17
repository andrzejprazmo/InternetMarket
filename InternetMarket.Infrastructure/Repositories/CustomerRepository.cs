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

        public async Task<string> CreateCustomer(Customer customer)
        {
            using (var connection = _databaseConnectionProvider.GetNorthwindConnection())
            {
                string sqlQuery = @"INSERT INTO [dbo].[Customers]
                       ([CustomerID]
                       ,[CompanyName]
                       ,[ContactName]
                       ,[ContactTitle]
                       ,[Address]
                       ,[City]
                       ,[PostalCode]
                       ,[Country]
                       ,[Phone]
                       ,[Fax])
                 VALUES
                       (@Id
                       ,@CompanyName
                       ,@ContactName
                       ,@ContactTitle
                       ,@Address
                       ,@City
                       ,@PostalCode
                       ,@Country
                       ,@Phone
                       ,@Fax);
                SELECT @Id";

                return await connection.QuerySingleAsync<string>(sqlQuery, customer);
            }
        }

        public async Task<Customer> GetCustomerById(string customerId)
        {
            using (var connection = _databaseConnectionProvider.GetNorthwindConnection())
            {
                string sqlQuery = @"SELECT TOP (1) [CustomerID] AS Id
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

		public async Task<bool> IsCustomerExists(string customerId)
		{
            using (var connection = _databaseConnectionProvider.GetNorthwindConnection())
            {
                string sqlQuery = @"SELECT COUNT(*)
                  FROM [dbo].[Customers] WHERE [CustomerID] = @CustomerId";
                var result = await connection.QuerySingleOrDefaultAsync<int>(sqlQuery, new { CustomerId = customerId });

                return result > 0;
            }
        }
	}
}
