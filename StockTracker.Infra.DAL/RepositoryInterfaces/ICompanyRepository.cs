using StockTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockTracker.Infra.DAL.RepositoryInterfaces
{
    public interface ICompanyRepository
    {
        Company Insert(Company company);
        void Update(Company company);
        List<Company> List();
        Company Get(string stockCode, string stockExchangeCode);
        Company Get(string name);
    }
}
