namespace FlightBooking.AgentServices.PromptBuilder
{
    public interface ITravelPromptBuilder
    {
        string BuildPrompt(string userPrompt);
    }
}
