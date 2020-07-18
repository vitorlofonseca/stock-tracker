using StockTracker.Domain.Entities;

namespace StockTracker.Domain.Builders
{
    public static class NewsSourceBuilder
    {
        public static NewsSource ConstructOne()
        {
            return new NewsSource();
        }

        public static NewsSource WithCode(this NewsSource NewsSource, string Code)
        {
            NewsSource.Code = Code;
            return NewsSource;
        }

        public static NewsSource WithName(this NewsSource NewsSource, string Name)
        {
            NewsSource.Name = Name;
            return NewsSource;
        }
    }
}
