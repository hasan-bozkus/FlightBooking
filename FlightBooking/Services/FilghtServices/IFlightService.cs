using FlightBooking.Dtos.FlightDtos;

namespace FlightBooking.Services.FilghtServices
{
    public interface IFlightService
    {
        Task<List<ResultFlightDto>> GetAllFilghtAsync();
        Task<GetFlightByIdDto> GetFlightByIdDtoAsync(string id);
        Task CreateFlightAsync(CreateFlightDto createFlightDto);
        Task DeleteFlightAsync(string id);
        Task UpdateFlightAsync(UpdateFlightDto updateFlightDto);
    }
}
