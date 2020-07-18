using System;
using System.Collections.Generic;
using System.Text;

namespace StockTracker.Infra.HttpConsumer.NewsAPI.DTOs
{
    public class NewsAPIResponse
    {
        public string status;
        public int totalResults;
        public List<NewsDTO> articles;
    }

    public class NewsDTO
    {
        public SourceNewsDTO source;
        public string author;
        public string title;
        public string description;
        public string url;
        public string urlToImage;
        public DateTime publishedAt;
        public string content;
    }

    public class SourceNewsDTO
    {
        public string id;
        public string name;
    }
}
