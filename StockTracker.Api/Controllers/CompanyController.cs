using Microsoft.AspNetCore.Mvc;
using StockTracker.Api.DTOs;
using StockTracker.Api.Services;
using System;

namespace Compositions.Backend.Application.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private ICompanyService _companyService;

        public CompanyController(
            ICompanyService companyService
        ){
            _companyService = companyService;
        }

        [HttpPost]
        public IActionResult Insert(CompanyDTO company)
        {
            return Ok(_companyService.Insert(company));
        }


        [HttpGet("{subscriberId}/{stockExchangeCode}/{stockCode}")]
        public IActionResult Subscribe(Guid subscriberId, string stockExchangeCode, string stockCode)
        {
            _companyService.Subscribe(subscriberId, stockExchangeCode, stockCode);
            return Ok("ok");
        }
    }
}
