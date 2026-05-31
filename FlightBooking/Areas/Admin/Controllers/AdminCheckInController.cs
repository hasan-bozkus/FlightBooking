using AutoMapper;
using FlightBooking.Entities;
using FlightBooking.Services.BookingServices;
using FlightBooking.Settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace FlightBooking.Areas.Admin.Controllers
{
    public class AdminCheckInController : Controller
    {
        private readonly IBookingService _bookingService;

        public AdminCheckInController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [Area("Admin")]
        public async Task<IActionResult> Index(string id)
        {
            ViewBag.FlightNumber = TempData["FlightNumber"];
            ViewBag.DepartureTime = TempData["DepartureTime"];
            ViewBag.ArrivalTime = TempData["ArrivalTime"];
            //ViewBag.PassengerName = TempData["PassengerName"];
            //ViewBag.PnrNumber = TempData["PnrNumber"];

            var passenger = await _bookingService.GetPassengerNameAsync(id);
            ViewBag.PassengerName = passenger.Name + " " + passenger.Surname;

            return View();
        }
    }
}
