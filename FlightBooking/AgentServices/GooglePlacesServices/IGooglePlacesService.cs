using FlightBooking.Dtos.RestaurantDtos;

namespace FlightBooking.AgentServices.GooglePlacesServices
{
    public interface IGooglePlacesService
    {
        Task<List<RestaurantDto>> SearchRestaurantAsync(string query);
    }
}