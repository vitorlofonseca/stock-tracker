using Compositions.Backend.Application.Api.Exceptions;
using StockTracker.Api.DTOs;
using StockTracker.Domain.Aggregates;
using StockTracker.Domain.Builders;
using StockTracker.Domain.Entities;
using StockTracker.Domain.ValueObjects;
using StockTracker.Infra.SignalR.Services;
using StockTraker.Infra.DAL.RepositoryInterfaces;
using System;

namespace StockTracker.Api.Services
{
    public class CompanyService : ICompanyService
    {
        private ICompanyRepository _companyRepository;
        private ISubscriberRepository _subscriberRepository;
        private ISubscriptionRepository _subscriptionRepository;
        private INewsHubServices _newsHubService;

        public CompanyService(
            ICompanyRepository companyRepository, 
            ISubscriberRepository subscriberRepository, 
            ISubscriptionRepository subscriptionRepository,
            INewsHubServices newsHubService
        )
        {
            _companyRepository = companyRepository;
            _subscriberRepository = subscriberRepository;
            _subscriptionRepository = subscriptionRepository;
            _newsHubService = newsHubService;
        }

        public Company Insert(CompanyDTO companyDTO)
        {
            var company = CompanyBuilder.ConstructOne()
                .WithName(companyDTO.Name)
                .WithStockCode(companyDTO.StockCode)
                .WithStockExchange(
                    new StockExchange(){
                        Code = companyDTO.StockExchange.Code,
                        Name = companyDTO.StockExchange.Name
                    }
                );

            _companyRepository.Insert(company);

            _newsHubService.CreateNewsStream(companyDTO.StockExchange.Code, companyDTO.StockCode);

            return company;
        }

        public void Subscribe(Guid subscriberId, string stockExchangeCode, string stockCode)
        {
            var company = _companyRepository.Get(stockCode, stockExchangeCode);

            if (company == null)
            {
                throw new NotFoundException($"The company with stockCode {stockCode} and stockExchangeCode {stockExchangeCode} was not found");
            }

            var subscriber = _subscriberRepository.Get(subscriberId);

            if (subscriber == null)
            {
                throw new NotFoundException($"The subscriber with id {subscriber}");
            }

            var subscription = new Subscription()
            {
                Company = company,
                Subscriber = subscriber
            };

            _subscriptionRepository.Insert(subscription);
        }
    }
}
