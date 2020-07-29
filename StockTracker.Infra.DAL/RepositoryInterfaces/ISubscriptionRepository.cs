using StockTracker.Domain.Aggregates;
using StockTracker.Domain.Entities;
using System.Collections.Generic;

namespace StockTracker.Infra.DAL.RepositoryInterfaces
{
    public interface ISubscriptionRepository
    {
        Subscription Insert(Subscription subscription);
        void Remove(Subscription subscription);
        List<Subscription> List(Subscriber Subscriber);
    }
}
