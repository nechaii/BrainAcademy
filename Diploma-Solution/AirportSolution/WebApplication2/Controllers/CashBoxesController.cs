using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Airport.Model;
using WebApplication2.DAL;

namespace WebApplication2.Controllers
{
    public class CashBoxesController : Controller
    {
        private AirportContext db = new AirportContext();

        // GET: CashBoxes
        [HttpGet]
        public ActionResult Index()
        {
            var cashBoxes = db.CashBoxes.Include(c => c.BoardingCard);
            return View(cashBoxes.ToList().Take(10));
        }

        // GET: CashBoxes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CashBox cashBox = db.CashBoxes.Find(id);
            if (cashBox == null)
            {
                return HttpNotFound();
            }
            return View(cashBox);
        }

        // GET: CashBoxes/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.BoardingCards, "Id", "Id");
            return View();
        }

        // POST: CashBoxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateOperation,Sum,Rate")] CashBox cashBox)
        {
            if (ModelState.IsValid)
            {
                db.CashBoxes.Add(cashBox);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.BoardingCards, "Id", "Id", cashBox.Id);
            return View(cashBox);
        }

        // GET: CashBoxes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CashBox cashBox = db.CashBoxes.Find(id);
            if (cashBox == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.BoardingCards, "Id", "Id", cashBox.Id);
            return View(cashBox);
        }

        // POST: CashBoxes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateOperation,Sum,Rate")] CashBox cashBox)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cashBox).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.BoardingCards, "Id", "Id", cashBox.Id);
            return View(cashBox);
        }

        // GET: CashBoxes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CashBox cashBox = db.CashBoxes.Find(id);
            if (cashBox == null)
            {
                return HttpNotFound();
            }
            return View(cashBox);
        }

        // POST: CashBoxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CashBox cashBox = db.CashBoxes.Find(id);
            db.CashBoxes.Remove(cashBox);
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
