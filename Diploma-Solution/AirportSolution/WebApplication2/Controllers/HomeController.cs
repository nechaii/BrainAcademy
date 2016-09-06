using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApplication2.Controllers
{
    using Airport.Model.TimeTableObject;
    using ModelsView;
    using WebApplication2.DAL;
    using System.Data.Entity;

    public class HomeController : Controller
    {
        private AirportContext db = new AirportContext();

        public ActionResult Index()
        {
            var timeTable = db.TimeTables.Include(p => p.Flight.Airplane.Airline);

            List<TimeTableView> timeTableView = new List<TimeTableView>();

            foreach (var item in timeTable)
            {
                timeTableView.Add(new TimeTableView()
                {
                    Terminal = item.Terminal,
                    FlightNumber = item.Flight.FlightNumber,
                    FromPlace = item.FromPlace,
                    ToPlace = item.ToPlace,
                    ExpectedArrivalTime = item.ExpectedArrivalTime,
                    ExpectedDepartureTime = item.ExpectedDepartureTime,
                    FlightStatus = item.Flight.FlightStatus,
                    Airline = item.AirlineName
                });
            }

            return View(timeTableView);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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