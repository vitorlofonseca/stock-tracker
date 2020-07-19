using System;
using System.Collections.Generic;
using System.Text;

namespace StockTraker.Infra.DAL.Settings
{
    public class StockTrackerMongoSettings : IStockTrackerDatabaseSettings
    {
        public string SubscribersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CompaniesCollectionName { get; set; }
        public string SubscriptionsCollectionName { get; set; }
    }
}
