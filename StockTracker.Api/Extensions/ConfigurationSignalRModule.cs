using Microsoft.Extensions.DependencyInjection;
using StockTracker.Infra.SignalR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Compositions.Backend.Application.Api.Extensions
{
    public static class ConfigurationSignalRModule
    {
        public static IServiceCollection ConfigureSignalRModule(this IServiceCollection services)
        {
            services.AddScoped<INewsHubServices, NewsHubServices>();
            return services;
        }
    }
}
