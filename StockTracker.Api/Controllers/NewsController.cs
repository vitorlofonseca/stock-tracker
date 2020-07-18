using Microsoft.AspNetCore.Mvc;
using StockTracker.Api.Services;

namespace StockTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {
        private INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet("{stockExchangeCode}/{stockCode}")]
        public IActionResult Get(string stockExchangeCode, string stockCode)
        {
            return Ok(_newsService.GetNewsOfStock(stockExchangeCode, stockCode));
        }
    }
}
