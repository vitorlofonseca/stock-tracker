using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockTracker.Infra.Http.NewsAPI;
using StockTracker.Infra.HttpConsumer.SPIs;
using System;

namespace StockTracker.Api.Extensions
{
    public static class HttpConsumerExtension
    {
        public static IServiceCollection ConfigureHttpConsumerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<INewsGetter, NewsAPI>("NewsAPI", service =>
            {
                service.BaseAddress = new Uri(configuration.GetValue<string>("Apis:NewsAPI:Host"));
            });

            return services;
        }
    }
}
