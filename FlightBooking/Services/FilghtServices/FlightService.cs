using AutoMapper;
using FlightBooking.Dtos.FlightDtos;
using FlightBooking.Dtos.PassengersDtos;
using FlightBooking.Entities;
using FlightBooking.Settings;
using MongoDB.Driver;

namespace FlightBooking.Services.FilghtServices
{
    public class FlightService : IFlightService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Flight> _flightsCollection;
        private readonly IMongoCollection<Booking> _bookingsCollection;

        public FlightService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _mapper = mapper;
            _flightsCollection = database.GetCollection<Flight>(_databaseSettings.FlightCollectionName);
            _bookingsCollection = database.GetCollection<Booking>(_databaseSettings.BookingCollectionName);
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

        public async Task<GetFlightByIdDto> GetFlightByIdAsync(string id)
        {
            return _mapper.Map<GetFlightByIdDto>(await _flightsCollection.Find(x => x.FlightId == id).FirstOrDefaultAsync());
        }

        public async Task<List<PassengerListItemDto>> GetFlightWithPassengersAsync(string id)
        {
            // İlgili uçuşun tüm rezervasyonlarını çek
            var bookings = await _bookingsCollection.Find(x => x.FlightId == id).ToListAsync();

            // her rezervasyon içinde bulunan yolcuları düzleştir ve dto'ya map'le
            var passengers = bookings.SelectMany(y => y.Passengers.Select(z => new PassengerListItemDto
            {
                Name = z.Name,
                Surname = z.Surname,
                Email = y.ContactEmail, //yolcuya ait eposta yoksa iletişim epostasını kullan
                Gender = z.Gender,
                PassengerType = z.PassengerType,
                PnrNumber = y.PnrNumber, //pnr olarak bookingid kullanılıyor
                Phone = y.ContactPhone,
                //lazım olursa eklenir
                SeatNumber = z.SeatNumber,
                CheckInStatus = z.CheckInStatus,
                PaymentStatus = z.PaymentStatus,
                TicketStatus = z.TicketStatus,
                PassengerId = z.PassengerId
            })).ToList();

            return passengers;
        }

        public async Task UpdateFlightAsync(UpdateFlightDto updateFlightDto)
        {
            var mapper = _mapper.Map<Flight>(updateFlightDto);
            await _flightsCollection.FindOneAndReplaceAsync(x => x.FlightId == updateFlightDto.FlightId, mapper);
        }
    }
}
