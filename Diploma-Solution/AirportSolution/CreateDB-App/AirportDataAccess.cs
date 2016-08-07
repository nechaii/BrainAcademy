using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDB_App
{
    using System.Data.Entity;
    using Airport.Model;
    using Airport.Model.AirplaneObject;
    using System.IO;
    using Airport.Model.BoardingCardObject;
    using Airport.Model.CustomerObject;
    using Airport.Model.TimeTableObject;

    class AirportDataAccess
    {
    }

    public class AirportContext : DbContext
    {
        public AirportContext() : base("AirportDBLocal")
        {
            string dbFolder = "App_Data";
            string appPath = Directory.GetCurrentDirectory();
            string pathToDb = Path.GetFullPath(Path.Combine(appPath, @"..\..\")) + dbFolder;
            AppDomain.CurrentDomain.SetData("DataDirectory", pathToDb);
        }

        public DbSet<Seat> Seats { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<BoardingCard> BoardingCards { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }
        public DbSet<CashBox> CashBoxes { get; set; }
    }
}
