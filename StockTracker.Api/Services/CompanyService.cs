using StockTracker.Api.DTOs;
using StockTracker.Domain.Builders;
using StockTracker.Domain.Entities;
using StockTracker.Domain.ValueObjects;
using StockTraker.Infra.DAL.RepositoryInterfaces;

namespace StockTracker.Api.Services
{
    public class CompanyService : ICompanyService
    {
        private ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
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

            return _companyRepository.Insert(company);
        }
    }
}
