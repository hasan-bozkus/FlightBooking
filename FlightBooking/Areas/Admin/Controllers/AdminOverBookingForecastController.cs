using FlightBooking.Services.OverBookingNoShowServices;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminOverBookingForecastController : Controller
    {
        private readonly NoShowPredictionService _noShowPredictionService;

        public AdminOverBookingForecastController(NoShowPredictionService noShowPredictionService)
        {
            _noShowPredictionService = noShowPredictionService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _noShowPredictionService.PredictJanuary2027Async();
            return View(values);
        }
    }
}
