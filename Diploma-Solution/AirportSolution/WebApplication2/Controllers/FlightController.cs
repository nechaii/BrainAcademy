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

    using Airport.Model;
    using WebApplication2.DAL;

    public class FlightController : Controller
    {
        private AirportContext db = new AirportContext();

        // GET: Flight
        public ActionResult Index()
        {
            var flights = db.Flights.Include(f => f.Airplane).Include(f => f.TimeTable);
            return View(flights.ToList().OrderBy(p => p.FlightStatus));
        }

        // GET: Flight/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // GET: Flight/Create
        public ActionResult Create()
        {
            ViewBag.AirplaneId = new SelectList(db.Airplanes, "Id", "Name");
            ViewBag.Id = new SelectList(db.TimeTables, "Id", "Id");
            return View();
        }

        // POST: Flight/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateAdded,DepartureTime,ArrivalTime,FlightStatus,FlightNumber,Direct,Terminal,FromPlace,ToPlace,AirplaneId")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.Flights.Add(flight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AirplaneId = new SelectList(db.Airplanes, "Id", "Name", flight.AirplaneId);
            ViewBag.Id = new SelectList(db.TimeTables, "Id", "Id", flight.Id);
            return View(flight);
        }

        // GET: Flight/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            ViewBag.AirplaneId = new SelectList(db.Airplanes, "Id", "Name", flight.AirplaneId);
            ViewBag.Id = new SelectList(db.TimeTables, "Id", "Id", flight.Id);
            return View(flight);
        }

        // POST: Flight/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateAdded,DepartureTime,ArrivalTime,FlightStatus,FlightNumber,Direct,Terminal,FromPlace,ToPlace,AirplaneId")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AirplaneId = new SelectList(db.Airplanes, "Id", "Name", flight.AirplaneId);
            ViewBag.Id = new SelectList(db.TimeTables, "Id", "Id", flight.Id);
            return View(flight);
        }

        // GET: Flight/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: Flight/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flight flight = db.Flights.Find(id);
            db.Flights.Remove(flight);
            db.SaveChanges();
            return RedirectToAction("Index");
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
