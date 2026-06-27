using FlightBooking.MachineLearningModels;
using FlightBooking.Services.MachineLearningServices;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminForecastController : Controller
    {
        private readonly MongoFlightDataService _mongoFlightDataService;
        private readonly FlightMLService _flightMLService;

        public AdminForecastController(MongoFlightDataService mongoFlightDataService, FlightMLService flightMLService)
        {
            _mongoFlightDataService = mongoFlightDataService;
            _flightMLService = flightMLService;
        }

        public async Task<IActionResult> TrainModel()
        {
            var mlData = await _mongoFlightDataService.ConvertToMlDataAsync();
            _flightMLService.Train(mlData);

            ViewBag.Message = "Model başarıyla eğitildi.";

            return View();
        }

        [HttpGet]
        public IActionResult Predict()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Predict(DateTime flightDate, string flightType)
        {
            var input = new FlightData
            {
                Month = flightDate.Month,

                DayOfWeek = (float)flightDate.DayOfWeek,

                FlightType = flightType == "Morning" ? 0 : 1
            };

            var prediction = _flightMLService.Predict(input);

            ViewBag.Result = prediction.PredictedLabel
                ? "Bu uçuş büyük ihtimal dolacaktır."
                : "Bu uçuşta yoğunluk düşük görünüyor.";

            ViewBag.Probability = prediction.Probability;

            return View();
        }

    }
}
