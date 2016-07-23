namespace Airport.Model
{
    using System;
    using System.Collections.Generic;
    using Airport.Model.AirplaneObject;
    using Airport.Model.TimeTableObject;
    using Airport.Model.CustomerObject;
    using BoardingCardObject;

    public class Flight
    {
        public int Id { get; set; }
        public string FlightNum { get; set; }
        public Direct FligthDirect { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public Terminal TerminalGate { get; set; }
        public FlightStatus FlightStatus { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public Airplane Airplane { get; set; }
        public List<Customer> CustomerList { get; set; }
        public List<BoardingCard> BoardingCardList { get; set; }
    }
}
