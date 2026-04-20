using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBookingController : Controller
    {
        public IActionResult BookingList()
        {
            return View();
        }

        public IActionResult CreateBooking()
        {
            return View();
        }
    }
}
