namespace Airport.Model.AirplaneObject
{
    using System.Collections.Generic;

    public class Airplane
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public List<Seat> SeatTypeList { get; set; }

        public Airplane()
        {
        }
    }
}
