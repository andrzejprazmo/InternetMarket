using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace InternetMarket.Core.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCore(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(typeof(ServiceCollectionExtensions).Assembly);

            return serviceCollection;
        }
    }
}
