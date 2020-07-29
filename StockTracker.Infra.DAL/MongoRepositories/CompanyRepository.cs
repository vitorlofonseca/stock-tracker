using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using StockTracker.Domain.Entities;
using StockTracker.Infra.DAL.RepositoryInterfaces;
using StockTracker.Infra.DAL.Settings;
using System.Collections.Generic;

namespace StockTracker.Infra.DAL.MongoRepositories
{
    public class CompanyRepository: MongoContext, ICompanyRepository
    {
        public CompanyRepository(IOptions<StockTrackerMongoSettings> dbSettings) : base(dbSettings) { }

        public Company Insert(Company company)
        {
            _companies.InsertOne(company);
            return company;
        }

        public void Update(Company company)
        {
            _companies.ReplaceOne(dbCompany => 
                dbCompany.StockCode == company.StockCode &&
                dbCompany.StockExchange.Code == company.StockExchange.Code
            , company);
        }

        public List<Company> List()
        {
            return _companies.Find(book => true).ToList();
        }

        public Company Get(string stockCode, string stockExchangeCode)
        {
            return _companies.Find<Company>(company => company.StockCode == stockCode && company.StockExchange.Code == stockExchangeCode).FirstOrDefault();
        }

        public Company Get(string name)
        {
            return _companies.Find<Company>(company => company.Name == name).FirstOrDefault();
        }
    }
}
