using Microsoft.AspNetCore.SignalR;
using StockTracker.Domain.Entities;
using StockTracker.Infra.DAL.RepositoryInterfaces;
using StockTracker.Infra.HttpConsumer.SPIs;
using StockTracker.Infra.Messaging.HubConfig;
using StockTracker.Infra.Messaging.TimerFeatures;

namespace StockTracker.Infra.Messaging.Services
{
    public class NewsHubServicesSignalR: INewsHubServices
    {
        private ICompanyRepository _companyRepository;
        private IHubContext<NewsHub> _hub;
        private INewsGetter _newsGetter;

        public NewsHubServicesSignalR(IHubContext<NewsHub> hub,
            ICompanyRepository companyRepository,
            INewsGetter newsGetter
        )
        {
            _hub = hub;
            _companyRepository = companyRepository;
            _newsGetter = newsGetter;

            initializeStreams();
        }

        private void initializeStreams()
        {
            var companies = _companyRepository.List();

            foreach(var company in companies)
            {
                CreateNewsStream(company);
            }
        }

        public void CreateNewsStream(Company company)
        {

            new TimerManager(() =>
                _hub.Clients.All.SendAsync(
                    $"subscription_{company.StockExchange.Code}:{company.StockCode}",
                    _newsGetter.GetNewsByCompany(company).Result
                )
            );
        }
    }
}
