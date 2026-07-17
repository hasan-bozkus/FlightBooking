using FlightBooking.Dtos.AgentDtos;

namespace FlightBooking.AgentServices
{
    public interface ITravelAgentService
    {
        //Task<string> GetRestaurantRecommendationAsync(string cityName);
        //Task<string> AskAgentAsync(string prompt);
        Task<AgentResponseDto> AskAgentAsync(string prompt);
    }
}
