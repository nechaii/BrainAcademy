using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApplication1.Controllers
{
    using WebApplication1.DAL;

    public class HomeController : Controller
    {        
        public ActionResult Index()
        {
            FlightRepository flightRepository = new FlightRepository();

            return View(flightRepository.GetFlight());
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
    }
}