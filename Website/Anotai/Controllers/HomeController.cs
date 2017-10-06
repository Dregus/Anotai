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
        private Repositorio db = new Repositorio();

        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            HomeViewModel model = new HomeViewModel();
            model.Noticias = db.ListarNoticias();

            return View(model);
        }

        [HttpPost]
        public ActionResult Home(Usuario u)
        {
            return RedirectToAction("Investimentos", "Investidor");
        }
    }
}