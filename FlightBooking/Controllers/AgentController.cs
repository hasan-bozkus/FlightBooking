using FlightBooking.AgentServices;
using FlightBooking.Dtos.AgentDtos;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Controllers
{
    public class AgentController : Controller
    {
        private readonly ITravelAgentService _travelAgentService;

        public AgentController(ITravelAgentService travelAgentService)
        {
            _travelAgentService = travelAgentService;
        }

        //public async Task<IActionResult> Restaurant(string cityName)
        //{
        //    var result = await _travelAgentService.GetRestaurantRecommendationAsync(cityName);
        //    return Content(result);
        //}

        [HttpGet]
        public IActionResult AskAgent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AskAgent([FromBody] AgentPromptRepuestDto request)
        {
            var result = await _travelAgentService.AskAgentAsync(request.Prompt);
            return Json(result);
        }
    }
}
