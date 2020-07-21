using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using StockTracker.Domain.Aggregates;
using StockTracker.Domain.Entities;
using StockTraker.Infra.DAL.DALs;
using StockTraker.Infra.DAL.Settings;

namespace StockTraker.Infra.DAL.MongoRepositories
{
    public abstract class MongoContext
    {
        public IMongoCollection<SubscriberDTO> _subscribers;
        public IMongoCollection<Subscription> _subscriptions;
        public IMongoCollection<Company> _companies;

        public MongoContext(IOptions<StockTrackerMongoSettings> options)
        {
            var dbSettings = options.Value;

            var dbClient = new MongoClient(dbSettings.ConnectionString);
            var database = dbClient.GetDatabase(dbSettings.DatabaseName);

            _subscriptions = database.GetCollection<Subscription>(dbSettings.SubscriptionsCollectionName);
            _subscribers = database.GetCollection<SubscriberDTO>(dbSettings.SubscribersCollectionName);
            _companies = database.GetCollection<Company>(dbSettings.CompaniesCollectionName);
        }
    }
}
