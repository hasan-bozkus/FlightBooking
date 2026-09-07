using System.Text.Json.Serialization;

namespace FlightBooking.Models.FlightBookingModels
{
  // RapidAPI google-flights2 searchFlights yanıtı (yalnızca kullandığımız alanlar)
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

            // price bazen sayı (1410), bazen "unavailable" string geliyor.
            // Bu yüzden JsonElement olarak alıp sonra normalize ediyoruz.
            [JsonPropertyName("price")]
            public System.Text.Json.JsonElement Price { get; set; }
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
        }

        public class FlightApiAirport
        {
            [JsonPropertyName("airport_code")]
            public string? AirportCode { get; set; }
        }

        public class FlightApiLayover
        {
            [JsonPropertyName("city")]
            public string? City { get; set; }
        }
    }