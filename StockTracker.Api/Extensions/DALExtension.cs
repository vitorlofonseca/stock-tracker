using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using StockTracker.Domain.Entities;
using StockTracker.Infra.DAL.MongoRepositories;
using StockTracker.Infra.DAL.RepositoryInterfaces;
using StockTracker.Infra.DAL.Settings;

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
            services.AddScoped<ISubscriberRepository, SubscriberRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

            return services;
        }
    }
}
