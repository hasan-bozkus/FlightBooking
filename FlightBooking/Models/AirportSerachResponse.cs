using System.Text.Json.Serialization;

namespace FlightBooking.Models
{
    public class AirportSerachResponse
    {
        [JsonPropertyName("status")]
        public bool Status { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("data")]
        public List<AirportSerachData> Data { get; set; }
    }
}
