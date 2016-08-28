using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace WebApplication2.Controllers
{
    using System.Data;
    using System.Data.Entity;
    using Airport.Model.BoardingCardObject;
    using WebApplication2.DAL;
    using WebApplication2.ModelsView;

    public class BoardingCardsController : Controller
    {
        private AirportContext db = new AirportContext();

        // GET: BoardingCards
        [HttpGet]
        public ActionResult Index()
        {
            /*var boardingCards = db.BoardingCards.Include(b => b.CashBox).Include(b => b.Customer).Include(b => b.Flight). Where(b => b.BoardingCardStatus == BoardingCardStatus.Sold).Intersect(db.BoardingCards.Where(b => b.BoardingCardStatus == BoardingCardStatus.InStock));*/

            var boardingCards = db.BoardingCards.Include(b => b.CashBox).Include(b => b.Customer).Include(b => b.Flight);

            ICollection<BoardingCardsView> boardingCardsView  = new List<BoardingCardsView>();

            foreach (var p in boardingCards)
            {
                boardingCardsView.Add(new BoardingCardsView() {
                 Id = p.Id,
                 FirstName = p.Customer.FirstName,
                 DateAdded = p.DateAdded,
                 DateLastOperation = p.DateLastOperation,
                 BoardingCardStatus = p.BoardingCardStatus,
                 Price = p.Price,
                 SeatNum = p.SeatNum });
            }

            ViewBag.boardingCardsSold = boardingCardsView.Where(b => b.BoardingCardStatus == BoardingCardStatus.Sold).OrderByDescending(o => o.DateLastOperation).ToList();

            ViewBag.boardingCardsInStock = boardingCardsView.Where(b => b.BoardingCardStatus == BoardingCardStatus.InStock).ToList();

            return View();
        }

        // GET: BoardingCards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardingCard boardingCard = db.BoardingCards.Find(id);
            if (boardingCard == null)
            {
                return HttpNotFound();
            }
            return View(boardingCard);
        }

        // GET: BoardingCards/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.CashBoxes, "Id", "Id");
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName");
            ViewBag.FlightId = new SelectList(db.Flights, "Id", "FromPlace");
            return View();
        }

        // POST: BoardingCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateAdded,DateLastOperation,BoardingCardStatus,Price,SeatNum,CustomerId,FlightId")] BoardingCard boardingCard)
        {
            if (ModelState.IsValid)
            {
                db.BoardingCards.Add(boardingCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.CashBoxes, "Id", "Id", boardingCard.Id);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", boardingCard.CustomerId);
            ViewBag.FlightId = new SelectList(db.Flights, "Id", "FromPlace", boardingCard.FlightId);
            return View(boardingCard);
        }

        // GET: BoardingCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardingCard boardingCard = db.BoardingCards.Find(id);
            if (boardingCard == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.CashBoxes, "Id", "Id", boardingCard.Id);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", boardingCard.CustomerId);
            ViewBag.FlightId = new SelectList(db.Flights, "Id", "FromPlace", boardingCard.FlightId);
            return View(boardingCard);
        }

        // POST: BoardingCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateAdded,DateLastOperation,BoardingCardStatus,Price,SeatNum,CustomerId,FlightId")] BoardingCard boardingCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boardingCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.CashBoxes, "Id", "Id", boardingCard.Id);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", boardingCard.CustomerId);
            ViewBag.FlightId = new SelectList(db.Flights, "Id", "FromPlace", boardingCard.FlightId);
            return View(boardingCard);
        }

        // GET: BoardingCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoardingCard boardingCard = db.BoardingCards.Find(id);
            if (boardingCard == null)
            {
                return HttpNotFound();
            }
            return View(boardingCard);
        }

        // POST: BoardingCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoardingCard boardingCard = db.BoardingCards.Find(id);
            db.BoardingCards.Remove(boardingCard);
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
