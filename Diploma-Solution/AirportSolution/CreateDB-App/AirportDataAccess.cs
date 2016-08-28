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
        static AirportContext()
        {
            Database.SetInitializer(new AirportDBInitializer());
        }

        public AirportContext() : base("AirportDBLocal")
        {
            string dbFolder = "App_Data";
            string appPath = Directory.GetCurrentDirectory();
            string pathToDb = Path.GetFullPath(Path.Combine(appPath, @"..\..\")) + dbFolder;
            AppDomain.CurrentDomain.SetData("DataDirectory", pathToDb);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

           // modelBuilder.Entity<Seat>().HasMany(p => p.BoardingCard).WithOptional(e => e.Seat).HasForeignKey(h => h.SeatNum).WillCascadeOnDelete(false);
            
        }

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
