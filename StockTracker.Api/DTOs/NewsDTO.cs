using System;

namespace StockTracker.Api.DTOs
{
    public class NewsDTO
    {
        public string Url { get; set; }
        public NewsSourceDTO NewsSource { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Content { get; set; }
    }
}
