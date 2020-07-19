using Microsoft.AspNetCore.Mvc;
using StockTracker.Api.DTOs;
using StockTracker.Api.Services;

namespace StockTracker.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriberController : ControllerBase
    {
        private ISubscriberService _subscriberService;

        public SubscriberController(ISubscriberService subscriberService) {
            _subscriberService = subscriberService;
        }

        [HttpPost]
        public IActionResult Insert(SubscriberDTO subscriber)
        {
            return Ok(_subscriberService.Insert(subscriber));
        }
    }
}
