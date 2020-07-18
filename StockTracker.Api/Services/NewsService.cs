using StockTracker.Domain.Builders;
using StockTracker.Domain.Entities;
using StockTracker.Domain.ValueObjects;
using StockTracker.Infra.HttpConsumer.NewsAPI.DTOs;
using StockTracker.Infra.HttpConsumer.SPIs;
using System.Collections.Generic;
using System.Linq;

namespace StockTracker.Api.Services
{
    public class NewsService : INewsService
    {
        public INewsGetter _newsGetter;

        public NewsService(INewsGetter newsGetter)
        {
            _newsGetter = newsGetter;
        }

        public List<News> GetNewsOfStock(string stockExchangeCode, string stockCode)
        {
            // VVVVVVV In this point, the company is gotten from the database, according the stockCode and stockExchangeCode 
            var company = new Company()
            {
                Name = "American Airlines",
                StockCode = stockCode,
                StockExchange = new StockExchange() {
                    Name = "Anything",
                    Code = stockExchangeCode
                }
            };
            // ^^^^^^^ In this point, the company is gotten from the database, according the stockCode and stockExchangeCode 

            return _newsGetter.GetNewsByCompany(company).Result;
        }
    }
}
