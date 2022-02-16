using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using InternetMarket.Core.OldFashion;

namespace InternetMarket.Core.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCore(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(typeof(ServiceCollectionExtensions).Assembly);


            #region Old fashion

            serviceCollection.AddTransient<ICustomerService, CustomerService>();

			#endregion


			return serviceCollection;
        }
    }
}
