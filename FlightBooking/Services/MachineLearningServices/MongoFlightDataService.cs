using FlightBooking.Entities;
using FlightBooking.MachineLearningModels;
using FlightBooking.Settings;
using MongoDB.Driver;
using NuGet.Configuration;

namespace FlightBooking.Services.MachineLearningServices
{
    public class MongoFlightDataService
    {
        private readonly IMongoCollection<FlightRawData> _flightDemandHistoryCollection;

        public MongoFlightDataService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _flightDemandHistoryCollection = database.GetCollection<FlightRawData>(settings.FlightDemandHistoryCollectionName);
        }

        public async Task<List<FlightRawData>> GetAllAsync()
        {
            return await _flightDemandHistoryCollection.Find(_ => true).ToListAsync();
        }

        public async Task<List<FlightData>> ConvertToMlDataAsync()
        {
            var rawData = await GetAllAsync();

            var mlData = rawData.Select(x => new FlightData
            {
                Month = DateTime.Parse(x.FlightDate).Month,

                DayOfWeek = (float)DateTime.Parse(x.FlightDate).DayOfWeek,

                FlightType = x.FlightType == "Morning" ? 0 : 1,

                IsFull = x.PassengerCount >= x.Capacity * 0.9
            }).ToList();

            return mlData;
        }
    }
}
