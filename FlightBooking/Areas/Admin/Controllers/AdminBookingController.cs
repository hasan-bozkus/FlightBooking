using FlightBooking.Services.FilghtServices;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBookingController : Controller
    {
        private readonly IFlightService _flightService;

        public AdminBookingController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        public IActionResult BookingList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateBooking(string id)
        {
            var value = await _flightService.GetFlightByIdDtoAsync(id);
            ViewBag.FlightNumber = value.FlightNumber;
            ViewBag.DepartureAirportCode = value.DepartureAirportCode;
            ViewBag.DepartureAirportName = value.DepartureAirportName;
            ViewBag.ArrivalAirportCode = value.ArrivalAirportCode;
            ViewBag.ArrivalAirportName = value.ArrivalAirportName;
            ViewBag.DepartureTime = value.DepartureTime;
            ViewBag.ArrivalTime = value.ArrivalTime;
            ViewBag.AirlineCode = value.AirlineCode;

            return View();
        }
    }
}
