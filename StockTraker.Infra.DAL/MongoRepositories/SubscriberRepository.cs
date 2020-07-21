using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StockTracker.Domain.Builders;
using StockTracker.Domain.Entities;
using StockTraker.Infra.DAL.DALs;
using StockTraker.Infra.DAL.RepositoryInterfaces;
using StockTraker.Infra.DAL.Settings;
using System;

namespace StockTraker.Infra.DAL.MongoRepositories
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
