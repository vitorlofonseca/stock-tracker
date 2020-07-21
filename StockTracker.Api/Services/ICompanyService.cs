using StockTracker.Api.DTOs;
using StockTracker.Domain.Entities;
using System;

namespace StockTracker.Api.Services
{
    public interface ICompanyService
    {
        Company Insert(CompanyDTO subscriber);
        void Subscribe(Guid subscriberId, string stockExchangeCode, string stockCode);
    }
}
