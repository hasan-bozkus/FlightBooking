using FlightBooking.Dtos.FlightDtos;
using FlightBooking.Services.FilghtServices;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminFlightsController : Controller
    {
        private readonly IFlightService _flightService;

        public AdminFlightsController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        public async Task<IActionResult> FlightList()
        {
            var values = await _flightService.GetAllFilghtAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateFlight()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFlight(CreateFlightDto createFlightDto)
        {
            await _flightService.CreateFlightAsync(createFlightDto);
            return RedirectToAction("FlightList", "AdminFlights", new { area = "Admin" });
        }

        public async Task<IActionResult> DeleteFlight(string id)
        {
            await _flightService.DeleteFlightAsync(id);
            return RedirectToAction("FlightList", "AdminFlights", new { area = "Admin" });
        }

        [HttpGet]
        public IActionResult UpdateFlight(string id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFlight(UpdateFlightDto updateFlightDto)
        {
            await _flightService.UpdateFlightAsync(updateFlightDto);
            return RedirectToAction("FlightList", "AdminFlights", new { area = "Admin" });
        }

        public async Task<IActionResult> FlightDetail(string id)
        {
            var flight = await _flightService.GetFlightByIdAsync(id);
            var passenger = await _flightService.GetFlightWithPassengersAsync(id);

            ViewBag.FlightNumber = flight?.FlightNumber ?? "--";
            ViewBag.AirLineCode = flight?.AirlineCode ?? "--";
            ViewBag.DepartureAirportCode = flight?.DepartureAirportCode ?? "--";
            ViewBag.ArrivalAirportCode = flight?.ArrivalAirportCode ?? "--";
            ViewBag.DepartureTime = flight?.DepartureTime;
            ViewBag.ArrivalTime = flight?.ArrivalTime;
            ViewBag.TotalSeats = flight?.TotalSeats ?? 0;
            ViewBag.Status = flight?.Status ?? "--";
            //ViewBag.PassgengerId = flight?.PassgengerId ?? "--";

            ViewBag.Flight = flight;
            return View(passenger);
        }
    }
}
