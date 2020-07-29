using StockTracker.Domain.Entities;
using StockTracker.Infra.DAL.RepositoryInterfaces;
using StockTracker.Infra.HttpConsumer.Messaging;
using StockTracker.Infra.HttpConsumer.SPIs;
using StockTracker.Infra.Messaging.TimerFeatures;
using System;

namespace StockTracker.Infra.Messaging.Services
{
    public class NewsHubServicesTelegram: INewsHubServices
    {
        private ISubscriptionRepository _subscriptionRepository;
        private ICompanyRepository _companyRepository;
        private INewsGetter _newsGetter;
        private ISubscriberRepository _subscriberRepository;
        private IMessageService _telegramMessageService;

        public NewsHubServicesTelegram(
            ISubscriberRepository subscriberRepository,
            ISubscriptionRepository subscriptionRepository,
            ICompanyRepository companyRepository,
            INewsGetter newsGetter,
            IMessageService telegramMessageService
        ) {
            _subscriberRepository = subscriberRepository;
            _subscriptionRepository = subscriptionRepository;
            _newsGetter = newsGetter;
            _telegramMessageService = telegramMessageService;
            _companyRepository = companyRepository;

            InitializeStreams();
        }

        public void InitializeStreams()
        {
            var subscriberGuid = new Guid(Environment.GetEnvironmentVariable("USER_ID"));
            var subscriber = _subscriberRepository.Get(subscriberGuid);

            var subscriptions = _subscriptionRepository.List(subscriber);

            foreach (var subscription in subscriptions)
            {
                CreateNewsStream(subscription.Company);
            }
        }

        public void CreateNewsStream(Company company)
        {
            Action action = () =>
            {
                var companyNews = _newsGetter.GetNewsByCompany(company).Result;

                foreach(var news in companyNews)
                {
                    if (company.LastNews >= news.PublishedAt)
                    {
                        continue;
                    }

                    _telegramMessageService.SendMessage(news);
                }

                company.LastNews = companyNews[0].PublishedAt;
                company.News = companyNews;

                _companyRepository.Update(company);
            };

            new TimerManager(action);
        }
    }
}
