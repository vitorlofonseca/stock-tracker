using System;
using System.Collections.Generic;
using System.Text;

namespace StockTracker.Infra.SignalR.Services
{
    public interface INewsHubServices
    {
        void CreateNewsStream(string stockExchangeCode, string stockCode);
    }
}
