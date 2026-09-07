using FlightBooking.Models;
using System.Text.Json;

namespace FlightBooking.Services.AirportServices
{
    public class AirportService : IAirportService //0d8cb4f5b0mshcf6e94f4f120a03p1e6e5bjsn85b6be86fe40
    {
        private readonly HttpClient _httpClient;

        public AirportService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AirportResult?> GetFirstIataAsync(string query)
        {
            var list = await SearchAirportsAsync(query);
            return list.FirstOrDefault();
        }

        public async Task<List<AirportResult>> SearchAirportsAsync(string query)
        {
            var results = new List<AirportResult>();

            if (string.IsNullOrWhiteSpace(query))
                return results;

            // API isteğini kur
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(
                    $"https://google-flights2.p.rapidapi.com/api/v1/searchAirport" +
                    $"?query={Uri.EscapeDataString(query)}&language_code=en-US&country_code=US"),
                Headers =
                {
                    { "x-rapidapi-key", "0d8cb4f5b0mshcf6e94f4f120a03p1e6e5bjsn85b6be86fe40" },
                    { "x-rapidapi-host", "google-flights2.p.rapidapi.com" },
                },
            };

            using var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();

            // JSON'u modele çevir
            var parsed = JsonSerializer.Deserialize<AirportSerachResponse>(body);

            if (parsed?.Data == null)
                return results;

            // data[] -> her şehir -> list[] -> her havalimanı dolaş
            foreach (var data in parsed.Data)
            {
                foreach (var airport in data.List)
                {
                    // Sadece gerçek havalimanlarını al ve IATA kodu 3 harfli olanları
                    if (airport.Type == "airport" && !string.IsNullOrWhiteSpace(airport.Id))
                    {
                        results.Add(new AirportResult
                        {
                            Iata = airport.Id,                 // <-- IATA kodu burada
                            AirportName = airport.Title ?? "",
                            City = airport.City ?? data.City ?? "",
                            Title = data.Title ?? ""
                        });
                    }
                }
            }

            return results;
        }
    }
}
