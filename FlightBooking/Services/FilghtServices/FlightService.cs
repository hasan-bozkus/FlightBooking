using AutoMapper;
using FlightBooking.Dtos.FlightDtos;
using FlightBooking.Entities;
using FlightBooking.Settings;
using MongoDB.Driver;

namespace FlightBooking.Services.FilghtServices
{
    public class FlightService : IFlightService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Flight> _flightsCollection;

        public FlightService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _mapper = mapper;
            _flightsCollection = database.GetCollection<Flight>(_databaseSettings.FlightCollectionName);
        }

        public async Task CreateFlightAsync(CreateFlightDto createFlightDto)
        {
            var mapper = _mapper.Map<Flight>(createFlightDto);
            await _flightsCollection.InsertOneAsync(mapper);
        }

        public async Task DeleteFlightAsync(string id)
        {
            await _flightsCollection.DeleteOneAsync(flight => flight.FlightId == id);
        }

        public async Task<List<ResultFlightDto>> GetAllFilghtAsync()
        {
            return _mapper.Map<List<ResultFlightDto>>(await _flightsCollection.Find(x => true).ToListAsync());
        }

        public async Task<GetFlightByIdDto> GetFlightByIdDtoAsync(string id)
        {
            return _mapper.Map<GetFlightByIdDto>(await _flightsCollection.Find(x => x.FlightId == id).FirstOrDefaultAsync());
        }

        public async Task UpdateFlightAsync(UpdateFlightDto updateFlightDto)
        {
            var mapper = _mapper.Map<Flight>(updateFlightDto);
            await _flightsCollection.FindOneAndReplaceAsync(x => x.FlightId == updateFlightDto.FlightId, mapper);
        }
    }
}
