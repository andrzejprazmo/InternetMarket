using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket.Infrastructure.Providers
{
    public interface IDatabaseConnectionProvider
    {
        SqlConnection GetAdwentureWorksConnection();
    }
    public class DatabaseConnectionProvider : IDatabaseConnectionProvider
    {
        private readonly IConfiguration _configuration;
        public DatabaseConnectionProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public SqlConnection GetAdwentureWorksConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("AdwentureWorks"));
        }
    }
}
