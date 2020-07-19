using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using StockTraker.Infra.DAL.MongoRepositories;
using StockTraker.Infra.DAL.RepositoryInterfaces;
using StockTraker.Infra.DAL.Settings;

namespace StockTracker.Api.Extensions
{
    public static class DALExtension
    {
        public static IServiceCollection ConfigureDALLayer(this IServiceCollection services, IConfiguration config)
        {
            var dbConfig = config.GetSection("StockTrackerMongoSettings");
            services.Configure<StockTrackerMongoSettings>(dbConfig);

            services.AddSingleton<IStockTrackerDatabaseSettings, StockTrackerMongoSettings>();

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ISubscribersRepository, SubscribersRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

            return services;
        }
    }
}
