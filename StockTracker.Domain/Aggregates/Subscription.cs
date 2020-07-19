using StockTracker.Domain.Entities;
using StockTracker.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockTracker.Domain.Aggregates
{
    public class Subscription
    {
        public Subscriber Subscriber { get; set; }
        public Company Company { get; set; }
    }
}
