using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Anotai.Controllers
{
    public class InvestidorController : Controller
    {
        // GET: Investidor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Investir()
        {
            return View();
        }

        public ActionResult Perfil()
        {
            return View();
        }

        public ActionResult Investimentos()
        {
            return View("Meus_Investimentos");
        }
    }
}