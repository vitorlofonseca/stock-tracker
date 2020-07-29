using StockTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockTracker.Infra.Messaging.Services
{
    public interface INewsHubServices
    {
        void CreateNewsStream(Company company);
    }
}
