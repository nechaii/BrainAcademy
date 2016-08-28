using System;
using System.Collections.Generic;
using System.Web;


namespace WebApplication2.Controllers
{
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using WebApplication2.DAL;
    using WebApplication2.ModelsView;
    using Airport.Model.TimeTableObject;

    public class FlightViewController : Controller
    {
        private AirportContext db = new AirportContext();

        [HttpGet]
        public ActionResult Index()
        {
            db.Configuration.LazyLoadingEnabled = true;
            IQueryable<FlightView> flights = db.Flights.
                Select(p => new FlightView
                {
                    FlightNumber = p.FlightNumber,
                    FlightStatus = p.FlightStatus,
                    FromPlace = p.FromPlace,
                    ToPlace = p.ToPlace,
                    ArrivalTime = p.ArrivalTime,
                    DepartureTime = p.DepartureTime
                });

            return View(flights.Take(10).ToList().OrderBy(p => p.FlightStatus));
        }

        [HttpGet]
        public ActionResult DepartedDetail()
        {
            db.Configuration.LazyLoadingEnabled = true;
            IQueryable<FlightViewDetail> flights = db.Flights.Where(s => s.FlightStatus == FlightStatus.Departed).
                Select(p => new FlightViewDetail
                {
                    FlightNumber = p.FlightNumber,
                    FlightStatus = p.FlightStatus,
                    FromPlace = p.FromPlace,
                    ToPlace = p.ToPlace,
                    ArrivalTime = p.ArrivalTime,
                    DepartureTime = p.DepartureTime
                });

            return View(flights.ToList().OrderByDescending(p => p.DepartureTime));
        }

        [HttpGet]
        public ActionResult ArrivedDetail()
        {
            db.Configuration.LazyLoadingEnabled = true;
            IQueryable<FlightViewDetail> flights = db.Flights.Where(s => s.FlightStatus == FlightStatus.Arrived).
                Select(p => new FlightViewDetail
                {
                    FlightNumber = p.FlightNumber,
                    FlightStatus = p.FlightStatus,
                    FromPlace = p.FromPlace,
                    ToPlace = p.ToPlace,
                    ArrivalTime = p.ArrivalTime,
                    DepartureTime = p.DepartureTime
                });

            return View(flights.ToList().OrderByDescending(p => p.DepartureTime));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}