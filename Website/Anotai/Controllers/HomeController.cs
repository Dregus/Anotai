using Anotai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Anotai.Controllers
{
    public class HomeController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Home(Usuario u)
        {
            return RedirectToAction("Investimentos", "Investidor");
        }
    }
}