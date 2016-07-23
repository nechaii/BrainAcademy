namespace Airport.Model
{
    using System.Collections.Generic;
    using Airport.Model.AirplaneObject;
    public class Airline
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public List<Airplane> AirplaneList { get; set; }
    }
}
