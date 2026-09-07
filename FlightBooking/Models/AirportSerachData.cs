
using System.Text.Json.Serialization;

namespace FlightBooking.Models
{
    public class AirportSerachData
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("subtitle")]
        public string? SubTitle { get; set; }

        [JsonPropertyName("city")]
        public string? City { get; set; }

        [JsonPropertyName("list")]
        public List<AirportItem> List { get; set; }
    }
}
