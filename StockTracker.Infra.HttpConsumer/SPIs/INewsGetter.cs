using StockTracker.Domain.Entities;
using StockTracker.Domain.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockTracker.Infra.HttpConsumer.SPIs
{
    public interface INewsGetter
    {
        Task<List<News>> GetNewsByCompany(Company Company);
    }
}
