using FlightBooking.Dtos.FlightDtos;
using FlightBooking.Dtos.PassengersDtos;

namespace FlightBooking.Services.FilghtServices
{
    public interface IFlightService
    {
        Task<List<ResultFlightDto>> GetAllFilghtAsync();
        Task<GetFlightByIdDto> GetFlightByIdAsync(string id);
        Task CreateFlightAsync(CreateFlightDto createFlightDto);
        Task DeleteFlightAsync(string id);
        Task UpdateFlightAsync(UpdateFlightDto updateFlightDto);
        Task<List<PassengerListItemDto>> GetFlightWithPassengersAsync(string id);
    }
}
