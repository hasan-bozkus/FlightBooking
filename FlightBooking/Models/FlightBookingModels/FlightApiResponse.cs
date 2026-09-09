using System.Text.Json.Serialization;

namespace FlightBooking.Models.FlightBookingModels
{
    public class FlightApiResponse
    {
        [JsonPropertyName("status")]
        public bool Status { get; set; }

        [JsonPropertyName("data")]
        public FlightApiData? Data { get; set; }
    }

    public class FlightApiData
    {
        [JsonPropertyName("itineraries")]
        public FlightApiItineraries? Itineraries { get; set; }
    }

    public class FlightApiItineraries
    {
        [JsonPropertyName("topFlights")]
        public List<FlightApiItinerary>? TopFlights { get; set; }

        [JsonPropertyName("otherFlights")]
        public List<FlightApiItinerary>? OtherFlights { get; set; }
    }

    public class FlightApiItinerary
    {
        [JsonPropertyName("departure_time")]
        public string? DepartureTime { get; set; }

        [JsonPropertyName("arrival_time")]
        public string? ArrivalTime { get; set; }

        [JsonPropertyName("duration")]
        public FlightApiDuration? Duration { get; set; }

        [JsonPropertyName("flights")]
        public List<FlightApiLeg>? Flights { get; set; }

        [JsonPropertyName("layovers")]
        public List<FlightApiLayover>? Layovers { get; set; }

        [JsonPropertyName("stops")]
        public int Stops { get; set; }

        [JsonPropertyName("airline_logo")]
        public string? AirlineLogo { get; set; }

        [JsonPropertyName("price")]
        public System.Text.Json.JsonElement Price { get; set; }

        // ---- YENİ: bagaj + karbon ----
        [JsonPropertyName("bags")]
        public FlightApiBags? Bags { get; set; }

        [JsonPropertyName("carbon_emissions")]
        public FlightApiCarbon? CarbonEmissions { get; set; }
    }

    public class FlightApiDuration
    {
        [JsonPropertyName("text")]
        public string? Text { get; set; }
    }

    public class FlightApiLeg
    {
        [JsonPropertyName("departure_airport")]
        public FlightApiAirport? DepartureAirport { get; set; }

        [JsonPropertyName("arrival_airport")]
        public FlightApiAirport? ArrivalAirport { get; set; }

        [JsonPropertyName("airline")]
        public string? Airline { get; set; }

        [JsonPropertyName("airline_logo")]
        public string? AirlineLogo { get; set; }

        // ---- YENİ: detay alanları ----
        [JsonPropertyName("flight_number")]
        public string? FlightNumber { get; set; }

        [JsonPropertyName("aircraft")]
        public string? Aircraft { get; set; }

        [JsonPropertyName("legroom")]
        public string? Legroom { get; set; }

        [JsonPropertyName("duration")]
        public FlightApiDuration? Duration { get; set; }
    }

    // ---- Airport: adı da lazım (detayda) ----
    public class FlightApiAirport
    {
        [JsonPropertyName("airport_code")]
        public string? AirportCode { get; set; }

        [JsonPropertyName("airport_name")]
        public string? AirportName { get; set; }

        [JsonPropertyName("time")]
        public string? Time { get; set; }
    }

    // ---- Layover: ad + süre etiketi ----
    public class FlightApiLayover
    {
        [JsonPropertyName("airport_code")]
        public string? AirportCode { get; set; }

        [JsonPropertyName("airport_name")]
        public string? AirportName { get; set; }

        [JsonPropertyName("city")]
        public string? City { get; set; }

        [JsonPropertyName("duration_label")]
        public string? DurationLabel { get; set; }
    }

    // ---- YENİ: bags ----
    public class FlightApiBags
    {
        [JsonPropertyName("carry_on")]
        public int? CarryOn { get; set; }

        [JsonPropertyName("checked")]
        public int? Checked { get; set; }
    }

    // ---- YENİ: carbon ----
    public class FlightApiCarbon
    {
        [JsonPropertyName("CO2e")]
        public int Co2e { get; set; }

        [JsonPropertyName("difference_percent")]
        public int DifferencePercent { get; set; }
    }
}