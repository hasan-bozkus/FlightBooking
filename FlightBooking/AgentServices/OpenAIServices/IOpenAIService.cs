using FlightBooking.Dtos.AgentDtos;

namespace FlightBooking.AgentServices.OpenAIServices
{
    public interface IOpenAIService
    {
        //Task<string> GetResponseAsync(string prompt);
        Task<AgentResponseDto> GetResponseAsync(string prompt);
    }
}
