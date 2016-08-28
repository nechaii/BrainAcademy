namespace WebApplication2.DAL
{
    using Airport.Model;
    using Airport.Model.AirplaneObject;
    using Airport.Model.BoardingCardObject;
    using Airport.Model.CustomerObject;
    using Airport.Model.TimeTableObject;
    using System.Data.Entity;

    public class AirportContext: DbContext
    {
        public AirportContext(): base("AirportContext")
        { }

        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<Airplane> Airplanes { get; set; }
        public virtual DbSet<Airline> Airlines { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<BoardingCard> BoardingCards { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<TimeTable> TimeTables { get; set; }
        public virtual DbSet<CashBox> CashBoxes { get; set; }
    }
}