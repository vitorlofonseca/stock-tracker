using StockTracker.Domain.Entities;
using System;

namespace StockTracker.Domain.ValueObjects
{
    public class News
    {
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        public NewsSource NewsSource { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Content { get; set; }
    }
}
