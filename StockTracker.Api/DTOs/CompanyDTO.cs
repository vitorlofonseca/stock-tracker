using System;
using System.Collections.Generic;

namespace StockTracker.Api.DTOs
{
    public class CompanyDTO
    {
        public string Name { get; set; }
        public string StockCode { get; set; }
        public StockExchangeDTO StockExchange { get; set; }
        public List<NewsDTO> News { get; set; }
    }

    public class StockExchangeDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class NewsSourceDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
