using FlightBooking.Dtos.CheckInDtos;
using FlightBooking.Entities;
using FlightBooking.Settings;
using Humanizer;
using MongoDB.Driver;

namespace FlightBooking.Services.CheckInServices
{
    public class CheckInService : ICheckInService
    {
        private readonly IMongoCollection<Booking> _bookingCollection;
        private readonly IMongoCollection<CheckIn> _checkInCollection;

        public CheckInService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _bookingCollection = database.GetCollection<Booking>(settings.BookingCollectionName);
            _checkInCollection = database.GetCollection<CheckIn>(settings.CheckInCollectionName);
        }

        public async Task CompleteCheckInAsync(CompleteCheckInDto completeCheckInDto)
        {
            var booking = await _bookingCollection.Find(x => x.Passengers.Any(p => p.PassengerId == completeCheckInDto.PassengerId)).FirstOrDefaultAsync();

            if (booking == null)
                throw new Exception("Booking Bulunamadı");

            var passenger = booking.Passengers.FirstOrDefault(p => p.PassengerId == completeCheckInDto.PassengerId);

            if (passenger == null)
                throw new Exception("Yolcu Bulunamadı");

            var boardingPass = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();

            var gates = new[] { "A1", "A2", "B5", "C3", "D7" };
            var randomGate = gates[new Random().Next(gates.Length)];

            var filter = Builders<Booking>.Filter.ElemMatch(x => x.Passengers, p => p.PassengerId == completeCheckInDto.PassengerId);

            var update = Builders<Booking>.Update
                       .Set("Passengers.$.IsCheckedIn", true)
                       .Set("Passengers.$.CheckInDate", DateTime.Now)
                       .Set("Passengers.$.SeatNumber", completeCheckInDto.SeatNumber)
                       .Set("Passengers.$.BaggageKg", completeCheckInDto.BaggageKg)
                       .Set("Passengers.$.MealType", completeCheckInDto.MealType)
                       .Set("Passengers.$.ExtraServices", completeCheckInDto.ExtraServices)
                       .Set("Passengers.$.BoardingPassNumber", boardingPass)
                       .Set("Passengers.$.Gate", randomGate)
                       .Set("Passengers.$.BoardingTime", DateTime.Now.AddMinutes(30));

            await _bookingCollection.UpdateOneAsync(filter, update);

            var checkIn = new CheckIn
            {
                CheckInId = Guid.NewGuid().ToString(),
                PassengerId = completeCheckInDto.PassengerId,
                FlightId = completeCheckInDto.FlightId,
                PnrNumber = completeCheckInDto.PnrNumber,
                CheckInDate = DateTime.Now,
                IsCheckedIn = true,
                SeatNumber = completeCheckInDto.SeatNumber,
                ExtraTotalPrice = completeCheckInDto.ExtraTotalPrice
            };

            await _checkInCollection.InsertOneAsync(checkIn);
        }
    }
}
