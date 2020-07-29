using StockTracker.Domain.Entities;
using System;

namespace StockTracker.Infra.DAL.RepositoryInterfaces
{
    public interface ISubscriberRepository
    {
        Subscriber Insert(Subscriber Subscriber);
        Subscriber Get(Guid Id);
    }
}
