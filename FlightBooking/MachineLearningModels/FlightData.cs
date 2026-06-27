namespace FlightBooking.MachineLearningModels
{
    public class FlightData
    {
        public float Month { get; set; }
        public float DayOfWeek { get; set; }
        public float FlightType { get; set; } //0: Morning, 1: Evenening
        public bool IsFull { get; set; }
    }
}
