using StockTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockTraker.Infra.DAL.RepositoryInterfaces
{
    public interface ICompanyRepository
    {
        Company Insert(Company company);
        List<Company> List();
        Company Get(string stockCode, string stockExchangeCode);
        Company Get(string name);
    }
}
