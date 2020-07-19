using StockTracker.Domain.Entities;
using System;

namespace StockTracker.Domain.Builders
{
    public static class SubscriberBuilder
    {
        public static Subscriber ConstructOne()
        {
            return new Subscriber();
        }

        public static Subscriber WithId(this Subscriber subscriber, Guid id)
        {
            subscriber.Id = id;
            return subscriber;
        }

        public static Subscriber WithName(this Subscriber subscriber, string name)
        {
            subscriber.Name = name;
            return subscriber;
        }
    }
}
