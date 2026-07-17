namespace FlightBooking.AgentServices.CityDedectors
{
    public interface ICityExtractor
    {
        Task<string?> ExtractCityAsync(string prompt);
    }
}
