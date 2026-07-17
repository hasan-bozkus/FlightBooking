using FlightBooking.AgentServices.IntentDetectors;
using FlightBooking.AgentServices.OpenAIServices;
using FlightBooking.AgentServices.PromptBuilder;
using FlightBooking.Dtos.AgentDtos;

namespace FlightBooking.AgentServices
{
    public class TravelAgentService : ITravelAgentService
    {
        private readonly IOpenAIService _openAIService;
        private readonly ITravelPromptBuilder _travelPromptBuilder;
        private readonly IIntentDetector _intentDetector;

        public TravelAgentService(IOpenAIService openAIService, IIntentDetector intentDetector)
        {
            _openAIService = openAIService;
            _intentDetector = intentDetector;
        }

        public async Task<AgentResponseDto> AskAgentAsync(string prompt)
        {
            var intent = _intentDetector.Detect(prompt);
            var finalPrompt = _travelPromptBuilder.BuildPrompt(prompt);
            return await _openAIService.GetResponseAsync(finalPrompt);
        }

        //public async Task<string> GetRestaurantRecommendationAsync(string cityName)
        //{
        //    var prompt = $"{cityName} şehrine giden bir turist için 5 restoran öner.";

        //    return await _openAIService.GetResponseAsync(prompt);
        //}
    }
}
