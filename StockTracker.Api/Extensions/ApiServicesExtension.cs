using Microsoft.Extensions.DependencyInjection;
using StockTracker.Api.Services;

namespace StockTracker.Api.Extensions
{
    public static class ApiServicesExtension
    {
        public static IServiceCollection ConfigureApiServices(this IServiceCollection services)
        {
            services.AddScoped<INewsService, NewsService>();

            return services;
        }
    }
}
