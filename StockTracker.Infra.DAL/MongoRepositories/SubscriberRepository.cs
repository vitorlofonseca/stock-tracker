using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StockTracker.Domain.Builders;
using StockTracker.Domain.Entities;
using StockTracker.Infra.DAL.DALs;
using StockTracker.Infra.DAL.RepositoryInterfaces;
using StockTracker.Infra.DAL.Settings;
using System;

namespace StockTracker.Infra.DAL.MongoRepositories
{
    public class SubscriberRepository: MongoContext, ISubscriberRepository
    {
        public SubscriberRepository(IOptions<StockTrackerMongoSettings> dbSettings): base (dbSettings) {}

        public Subscriber Insert(Subscriber subscriber)
        {
            subscriber.Id = Guid.NewGuid();
            var subscriberDTO = SubscriberDTO.FromDomain(subscriber);
            _subscribers.InsertOne(subscriberDTO);
            return subscriber;
        }

        public Subscriber Get(Guid Id)
        {
            var subscriberDTO = _subscribers.Find(subscriber => subscriber.Id == Id.ToString()).FirstOrDefault();
            return SubscriberBuilder.ConstructOne()
                .WithId(Guid.Parse(subscriberDTO.Id))
                .WithName(subscriberDTO.Name);
        }
    }
}
