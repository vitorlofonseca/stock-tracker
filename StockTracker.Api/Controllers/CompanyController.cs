using Microsoft.AspNetCore.Mvc;
using StockTracker.Api.DTOs;
using StockTracker.Api.Services;

namespace Compositions.Backend.Application.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        public IActionResult Insert(CompanyDTO company)
        {
            return Ok(_companyService.Insert(company));
        }
    }
}
