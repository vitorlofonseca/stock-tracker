using StockTracker.Domain.Entities;
using StockTracker.Domain.ValueObjects;
using System;

namespace StockTracker.Domain.Builders
{
    public static class NewsBuilder
    {
        public static News ConstructOne()
        {
            return new News();
        }

        public static News WithSource(this News News, NewsSource Source)
        {
            News.NewsSource = Source;
            return News;
        }

        public static News WithAuthor(this News News, string Author)
        {
            News.Author = Author;
            return News;
        }

        public static News WithTitle(this News News, string Title)
        {
            News.Title = Title;
            return News;
        }

        public static News WithDescription(this News News, string Description)
        {
            News.Description = Description;
            return News;
        }

        public static News WithUrl(this News News, string Url)
        {
            News.Url = Url;
            return News;
        }

        public static News WithPublishedAt(this News News, DateTime PublishedAt)
        {
            News.PublishedAt = PublishedAt;
            return News;
        }

        public static News WithContent(this News News, string Content)
        {
            News.Content = Content;
            return News;
        }
    }
}
