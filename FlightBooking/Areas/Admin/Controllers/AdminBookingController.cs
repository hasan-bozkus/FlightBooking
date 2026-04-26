using FlightBooking.Dtos.BookingDtos;
using FlightBooking.Services.BookingServices;
using FlightBooking.Services.FilghtServices;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBookingController : Controller
    {
        private readonly IFlightService _flightService;
        private readonly IBookingService _bookingService;

        public AdminBookingController(IFlightService flightService, IBookingService bookingService)
        {
            _flightService = flightService;
            _bookingService = bookingService;
        }

        public IActionResult BookingList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateBooking(string id)
        {
            var value = await _flightService.GetFlightByIdDtoAsync(id);
            ViewBag.FlightId = id;
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

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            if(!ModelState.IsValid)
            {
                return View(createBookingDto);
            }

            await _bookingService.CreateBookingAsync(createBookingDto);
            return RedirectToAction("BookingList", "AdminBooking", new { area = "Admin" });
        }
    }
}
