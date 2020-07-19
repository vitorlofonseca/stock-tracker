using StockTracker.Api.DTOs;
using StockTracker.Domain.Entities;

namespace StockTracker.Api.Services
{
    public interface ICompanyService
    {
        Company Insert(CompanyDTO subscriber);
    }
}
