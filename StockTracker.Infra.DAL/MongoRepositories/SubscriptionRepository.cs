using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StockTracker.Domain.Aggregates;
using StockTracker.Domain.Entities;
using StockTracker.Infra.DAL.RepositoryInterfaces;
using StockTracker.Infra.DAL.Settings;
using System.Collections.Generic;

namespace StockTracker.Infra.DAL.MongoRepositories
{
    public class SubscriptionRepository: MongoContext, ISubscriptionRepository
    {
        public SubscriptionRepository(IOptions<StockTrackerMongoSettings> dbSettings) : base(dbSettings) {}

        public Subscription Insert(Subscription subscription)
        {
            _subscriptions.ReplaceOneAsync(sub => 
                sub.Subscriber.Id == subscription.Subscriber.Id && sub.Company.StockCode == subscription.Company.StockCode,
            subscription,
            new UpdateOptions { IsUpsert = true });

            return subscription;
        }

        public List<Subscription> List(Subscriber subscriber)
        {
            return _subscriptions.Find(subscription => subscription.Subscriber.Id == subscriber.Id).ToList();
        }

        public void Remove(Subscription subscription)
        {
            _subscriptions.DeleteOne(dbSubscription => 
                dbSubscription.Subscriber.Id == subscription.Subscriber.Id &&
                dbSubscription.Company.StockCode == subscription.Company.StockCode &&
                dbSubscription.Company.StockExchange.Code == subscription.Company.StockExchange.Code
            );
        }
    }
}
