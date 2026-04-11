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
    }
}
