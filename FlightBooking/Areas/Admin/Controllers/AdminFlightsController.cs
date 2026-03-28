using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminFlightsController : Controller
    {
        public IActionResult FlightList()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateFlight()
        {
            return View();
        }
    }
}
