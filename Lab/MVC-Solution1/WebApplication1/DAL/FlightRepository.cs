using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.DAL
{
    using System.Data.Entity;
    using WebApplication1.Models.Entities;

    public class FlightRepository: IFlight
    {
        DbContext _db;

        public FlightRepository()
        {
            _db = new AirportContext();
        }

        public DateTime? ArrivalTime
        {
            get; set;
        }

        public DateTime? DepartureTime
        {
            get; set;
        }

        public int Id
        {
            get; set;
        }

        public string Number
        {
            get; set;
        }

        public ICollection<PassengerRepository> Passenger
        {
            get; set;
        }

        public ITerminal Terminal
        {
            get; set;
        }

        public int? TerminalId
        {
            get; set;
        }

        public ICollection<FlightRepository> GetFlight()
        {
            return ((AirportContext)_db).Flights.ToList();
        }
    }
}