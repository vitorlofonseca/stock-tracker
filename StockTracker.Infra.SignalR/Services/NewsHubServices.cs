using Microsoft.AspNetCore.SignalR;
using StockTracker.Infra.HttpConsumer.SPIs;
using StockTracker.Infra.SignalR.HubConfig;
using StockTracker.Infra.SignalR.TimerFeatures;
using StockTraker.Infra.DAL.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockTracker.Infra.SignalR.Services
{
    public class NewsHubServices: INewsHubServices
    {
        private ICompanyRepository _companyRepository;
        private IHubContext<NewsHub> _hub;
        private INewsGetter _newsGetter;

        public NewsHubServices(IHubContext<NewsHub> hub,
            ICompanyRepository companyRepository,
            INewsGetter newsGetter
        )
        {
            _hub = hub;
            _companyRepository = companyRepository;
            _newsGetter = newsGetter;
        }

        public void CreateNewsStream(string stockExchangeCode, string stockCode)
        {
            var company = _companyRepository.Get(stockCode, stockExchangeCode);

            new TimerManager(() =>
                _hub.Clients.All.SendAsync(
                    $"subscription_{stockExchangeCode}:{stockCode}",
                    _newsGetter.GetNewsByCompany(company).Result
                )
            );
        }
    }
}
