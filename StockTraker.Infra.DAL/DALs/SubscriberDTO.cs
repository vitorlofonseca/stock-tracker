using StockTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockTraker.Infra.DAL.DALs
{
    public class SubscriberDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public static SubscriberDTO FromDomain(Subscriber subscriber)
        {
            return new SubscriberDTO()
            {
                Id = subscriber.Id.ToString(),
                Name = subscriber.Name
            };
        }
    }
}
