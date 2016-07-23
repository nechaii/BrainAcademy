namespace Airport.Model.BoardingCardObject
{
    using Airport.Model.AirplaneObject;
    public class BoardingCard
    {
        public int Id { get; set; }
        public SeatType SeatType { get; set; }
        public double Price { get; set; }
        public string FlightNum { get; set; }
        public BoardingCardStatus Status { get; set; }
    }
}
