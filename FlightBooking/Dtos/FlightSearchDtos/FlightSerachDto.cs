namespace FlightBooking.Dtos.FlightSearchDtos
{
    // UI kartında gösterilecek sade uçuş modeli
    public class FlightCardDto
    {
        public string Airline { get; set; } = "";
        public string AirlineLogo { get; set; } = "";
        public string DepartureTime { get; set; } = "";   // "07:30"
        public string ArrivalTime { get; set; } = "";     // "08:35"
        public string DepartureAirport { get; set; } = ""; // "ESB"
        public string ArrivalAirport { get; set; } = "";   // "COV"
        public string DurationText { get; set; } = "";     // "1 hr 5 min"
        public int Stops { get; set; }                     // aktarma sayısı
        public List<string> LayoverCities { get; set; } = new(); // ["Istanbul"]
        public string Price { get; set; } = "";            // "1410" ya da "unavailable"
    }

    // Search action'ının UI'a döndüğü zarf
    public class FlightSearchResultDto
    {
        public bool Success { get; set; }
        public string? Error { get; set; }
        public string FromIata { get; set; } = "";
        public string FromAirport { get; set; } = "";
        public string ToIata { get; set; } = "";
        public string ToAirport { get; set; } = "";
        public string Currency { get; set; } = "TRY";
        public List<FlightCardDto> Flights { get; set; } = new();
    }
}
