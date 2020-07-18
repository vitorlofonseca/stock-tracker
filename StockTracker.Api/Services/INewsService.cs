using StockTracker.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace StockTracker.Api.Services
{
    public interface INewsService
    {
        List<News> GetNewsOfStock(string stockExchangeCode, string stockCode);
    }
}
