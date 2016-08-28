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

    public class TimeTableViewController : Controller
    {
        private AirportContext db = new AirportContext();

        // GET: TimeTableView
        [HttpGet]
        public ActionResult Index()
        {
            //Hurd1
            //var timeTable = (from tt in db.TimeTables
            //                 join f in db.Flights on tt.Id equals f.Id
            //                 join a in db.Airplanes on f.AirplaneId equals a.Id
            //                 join aa in db.Airlines on a.AirlineId equals aa.Id
            //                 select new SomeClass()
            //                 {
            //                     ExpectedArrivalTime = tt.ExpectedArrivalTime,
            //                     ExpectedDepartureTime = tt.ExpectedDepartureTime,
            //                     FlightNumber = f.FlightNumber,
            //                     Terminal = f.Terminal,
            //                     Airline = aa.Name
            //                 }).ToList();

            //Hurd2
            //var timeTable = db.TimeTables.Join(db.Flights,
            //    t => t.Id,
            //    f => f.Id,
            //    (t, f) => new { t, f }).Join(
            //    db.Airplanes,
            //    ff => ff.f.AirplaneId,
            //    a => a.Id,
            //    (ff, a) => new { ff, a }).Join(
            //    db.Airlines,
            //    aa => aa.a.AirlineId,
            //    ar => ar.Id,
            //    (aa, ar) => new { aa, ar }
            //    );

            //foreach (var item in timeTable)
            //{
            //    Console.WriteLine("{0}, {1}, {2}, {3}", item.aa.ff.t.ExpectedArrivalTime, item.aa.ff.f.FlightNumber, item.aa.a.Name, item.ar.Name);
            //}

            //Hurd3
            //var timeTable = db.TimeTables.Join(db.Flights,
            //            t => t.Id,
            //            f => f.Id,
            //            (t, f) => new SomeClass()
            //            {
            //                expAt = t.ExpectedArrivalTime,
            //                expDt = t.ExpectedDepartureTime,
            //                flight = f.FlightNumber,
            //                terminal = f.Terminal
            //            });

            //very simple
            var timeTable = db.TimeTables.Include(p => p.Flight.Airplane.Airline);
            /*.
                Select(p => new TimeTableView() {
                Terminal = p.Terminal,
                FlightNumber = p.Flight.FlightNumber,
                FromPlace = p.FromPlace,
                ToPlace = p.ToPlace,
                ExpectedArrivalTime = p.ExpectedArrivalTime,
                ExpectedDepartureTime = p.ExpectedDepartureTime,
                FlightStatus = p.Flight.FlightStatus,
                Airline = p.AirlineName
            });*/

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