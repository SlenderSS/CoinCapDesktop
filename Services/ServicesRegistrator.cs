using CoinCapDesktop.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinCapDesktop.Services
{
    static class ServicesRegistrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services) => services
            .AddScoped<ICoinCapService,CoinCapService>()
            ;
    }
}
