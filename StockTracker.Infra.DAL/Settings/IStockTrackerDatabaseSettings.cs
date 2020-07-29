using System;
using System.Collections.Generic;
using System.Text;

namespace StockTracker.Infra.DAL.Settings
{
    public interface IStockTrackerDatabaseSettings
    {
        string SubscribersCollectionName { get; set; }
        string CompaniesCollectionName { get; set; }
        string SubscriptionsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
