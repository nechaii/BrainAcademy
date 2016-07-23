namespace Airport.Model.TimeTableObject
{
    public enum FlightStatus : byte
    {
        Departed=1,
        Arrived,
        Expected,
        Boarding,
        Delay,
        Planned
    }
}
