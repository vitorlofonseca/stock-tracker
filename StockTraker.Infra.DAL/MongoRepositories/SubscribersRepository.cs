using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StockTracker.Domain.Entities;
using StockTraker.Infra.DAL.RepositoryInterfaces;
using StockTraker.Infra.DAL.Settings;
using System;

namespace StockTraker.Infra.DAL.MongoRepositories
{
    public class SubscribersRepository: MongoContext, ISubscribersRepository
    {
        public SubscribersRepository(IOptions<StockTrackerMongoSettings> dbSettings): base (dbSettings) {}

        public Subscriber Insert(Subscriber subscriber)
        {
            subscriber.Id = Guid.NewGuid();
            _subscribers.InsertOne(subscriber);
            return subscriber;
        }

        public Subscriber Get(Guid Id)
        {
            return _subscribers.Find(subscriber => subscriber.Id == Id).FirstOrDefault();
        }
    }
}
