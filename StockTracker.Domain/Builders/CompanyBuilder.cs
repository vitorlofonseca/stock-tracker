using StockTracker.Domain.Entities;
using StockTracker.Domain.ValueObjects;
using System.Collections.Generic;

namespace StockTracker.Domain.Builders
{
    public static class CompanyBuilder
    {
        public static Company ConstructOne()
        {
            return new Company();
        }

        public static Company WithName(this Company company, string name)
        {
            company.Name = name;
            return company;
        }

        public static Company WithStockCode(this Company company, string stockCode)
        {
            company.StockCode = stockCode;
            return company;
        }

        public static Company WithStockExchange(this Company company, StockExchange stockExchange)
        {
            company.StockExchange = stockExchange;
            return company;
        }

        public static Company WithNews(this Company company, List<News> news)
        {
            company.News = news;
            return company;
        }
    }
}
