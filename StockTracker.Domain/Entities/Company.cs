using StockTracker.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockTracker.Domain.Entities
{
    public class Company
    {
        public string Name { get; set; }
        public string StockCode { get; set; }
        public StockExchange StockExchange { get; set; }
        public List<News> News { get; set; }
    }
}
