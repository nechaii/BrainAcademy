using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.DAL
{
    using System.Data.Entity;
    using WebApplication1.Models.Entities;

    public class PassengerRepository : IPassenger
    {
        DbContext _db;

        public PassengerRepository()
        {
            _db = new AirportContext();
        }

        public string FirstName
        {
            get; set;
        }

        public int? FlightId
        {
            get; set;
        }

        public string Gender
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

        public string SecondName
        {
            get; set;
        }

        public string Series
        {
            get; set;
        }

        IFlight IPassenger.Flight
        {
            get; set;
        }
    }
}