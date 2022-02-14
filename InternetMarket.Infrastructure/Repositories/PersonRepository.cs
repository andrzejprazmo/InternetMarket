using InternetMarket.Core.Common.Interfaces;
using InternetMarket.Domain.Entities;
using InternetMarket.Infrastructure.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace InternetMarket.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IDatabaseConnectionProvider _databaseConnectionProvider;
        public PersonRepository(IDatabaseConnectionProvider databaseConnectionProvider)
        {
            _databaseConnectionProvider = databaseConnectionProvider;
        }

        public async Task<Person> GetPersonById(int personId)
        {
            using (var connection = _databaseConnectionProvider.GetAdwentureWorksConnection())
            {
                string sqlQuery = @"SELECT BusinessEntityID AS Id, Title, FirstName, LastName FROM [Person].[Person] WHERE BusinessEntityID=@PersonId";
                return await connection.QuerySingleAsync<Person>(sqlQuery, new { PersonId = personId });
            }
        }
    }
}
