namespace Airport.Model.TimeTableObject
{
    using System;
    public class TimeTable
    {
        public int Id { get; set; }
        public DateTime? ExpectedDepartureTime { get; set; }
        public DateTime? ExpectedArrivalTime { get; set; }
        public Direct FligthDirect { get; set; }
        public Flight Flight { get; set; }        
    }
}
