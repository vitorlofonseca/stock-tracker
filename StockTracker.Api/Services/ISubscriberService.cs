using StockTracker.Api.DTOs;
using StockTracker.Domain.Entities;

namespace StockTracker.Api.Services
{
    public interface ISubscriberService
    {
        Subscriber Insert(SubscriberDTO subscriber);
    }
}
