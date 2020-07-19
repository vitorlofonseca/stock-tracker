using StockTracker.Domain.Entities;
using System;

namespace StockTraker.Infra.DAL.RepositoryInterfaces
{
    public interface ISubscribersRepository
    {
        Subscriber Insert(Subscriber Subscriber);
        Subscriber Get(Guid Id);
    }
}
