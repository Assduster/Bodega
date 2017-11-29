using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bodega.dev.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Välkommen";

            return View();
        }

        public ActionResult Gallery()
        {
            ViewBag.Message = "Kontakt";

            return View();
        }
        public ActionResult Menu()
        {
            ViewBag.Message = "Meny";

            return View();
        }
    }
}