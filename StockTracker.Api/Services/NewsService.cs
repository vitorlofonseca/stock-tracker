using StockTracker.Domain.Entities;
using StockTracker.Domain.ValueObjects;
using StockTracker.Infra.HttpConsumer.SPIs;
using StockTracker.Infra.DAL.RepositoryInterfaces;
using System.Collections.Generic;

namespace StockTracker.Api.Services
{
    public class NewsService : INewsService
    {
        private INewsGetter _newsGetter;
        private ICompanyRepository _companyRepository;

        public NewsService(INewsGetter newsGetter, ICompanyRepository companyRepository)
        {
            _newsGetter = newsGetter;
            _companyRepository = companyRepository;
        }

        public List<News> GetNewsOfStock(string stockExchangeCode, string stockCode)
        {
            var company = _companyRepository.Get(stockCode, stockExchangeCode);

            return _newsGetter.GetNewsByCompany(company).Result;
        }
    }
}
