using GoogleWebService.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GoogleWebService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        public ActionResult Triathlons()
        {
            ViewBag.Title = "Triathlons";
            GoogleClass gg = new GoogleClass();
            Triathalon tt = new Triathalon();
            IList<Race> tris = tt.ProcessValues(gg.GetTriData());
            return View(tris);
        }

        public ActionResult Stats()
        {
            ViewBag.Title = "Stats";
            GoogleClass gg = new GoogleClass();
            Triathalon tt = new Triathalon();
            IList<Race> tris = tt.ProcessValues(gg.GetTriData());
            return View(tris);
        }

        public ActionResult Beers()
        {
            ViewBag.Title = "Beers";
            GoogleClass gg = new GoogleClass();
            Pubs pp = new Pubs();
            IList<Visit> beers = pp.ProcessValues(gg.GetBeerData());
            return View(beers);
        }

        public ActionResult BeersMap()
        {
            ViewBag.Title = "Beers";
            GoogleClass gg = new GoogleClass();
            Pubs pp = new Pubs();
            IList<Visit> beers = pp.ProcessValues(gg.GetBeerData());
            return View(beers);
        }
    }
}
