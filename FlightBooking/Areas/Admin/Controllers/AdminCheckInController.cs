using AutoMapper;
using FlightBooking.Dtos.CheckInDtos;
using FlightBooking.Entities;
using FlightBooking.Services.BookingServices;
using FlightBooking.Services.CheckInServices;
using FlightBooking.Settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace FlightBooking.Areas.Admin.Controllers
{
    public class AdminCheckInController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly ICheckInService _checkInService;

        public AdminCheckInController(IBookingService bookingService, ICheckInService checkInService)
        {
            _bookingService = bookingService;
            _checkInService = checkInService;
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

            var pnr = await _bookingService.GetPnrByPassengerIdAsync(id);
            ViewBag.PnrNumber = pnr;

            var gate = await _bookingService.GetGateByPassengerIdAsync(id);
            ViewBag.Gate = gate;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CompleteCheckInDto completeCheckInDto)
        {
            await _checkInService.CompleteCheckInAsync(completeCheckInDto);
            return RedirectToAction("Test");
        }
    }
}
