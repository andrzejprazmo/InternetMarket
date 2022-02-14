using InternetMarket.Core.Common.Interfaces;
using InternetMarket.Infrastructure.Providers;
using InternetMarket.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetMarket.Infrastructure.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IPersonRepository, PersonRepository>();
            serviceCollection.AddTransient<IDatabaseConnectionProvider, DatabaseConnectionProvider>();

            return serviceCollection;
        }
    }
}
