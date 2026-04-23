using FlightBooking.Dtos.BookingDtos;

namespace FlightBooking.Services.BookingServices
{
    public interface IBookingService
    {
        //Task<List<ResultBookingDto>> GetAllFilghtAsync();
        //Task<GetBookingByIdDto> GetBookingByIdDtoAsync(string id);
        Task CreateBookingAsync(CreateBookingDto createBookingDto);
        //Task DeleteBookingAsync(string id);
        //Task UpdateBookingAsync(UpdateBookingDto updateBookingDto);
    }
}