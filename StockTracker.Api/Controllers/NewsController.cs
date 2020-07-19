using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using StockTracker.Api.HubConfig;
using StockTracker.Api.Services;
using StockTracker.Api.TimerFeatures;

namespace StockTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {
        private INewsService _newsService;
        private IHubContext<NewsHub> _hub;

        public NewsController(IHubContext<NewsHub> hub, INewsService newsService)
        {
            _hub = hub;
            _newsService = newsService;
        }

        [HttpGet("{stockExchangeCode}/{stockCode}")]
        public IActionResult Get(string stockExchangeCode, string stockCode)
        {
            var timerManager = new TimerManager(() => 
                _hub.Clients.All.SendAsync(
                    "TransferStockNews", 
                    _newsService.GetNewsOfStock(stockExchangeCode, stockCode)
                )
            );

            return Ok("ok");
        }
    }
}
