using Anotai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Anotai.Controllers
{
    public class AdministradorController : Controller
    {
        // GET: Administrador
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Noticia()
        {
            return View("Gerenciar_Noticias");
        }

        public ActionResult CadastrarNoticia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarNoticia(Noticia n)
        {
            using (var ctx = new AnotaiContext())
            {
                if (n.Titulo != null && n.Mensagem != null)
                {
                    ctx.Noticias.Add(n);
                    ctx.SaveChanges();

                    ModelState.Clear();

                    ViewBag.Cadastrado = "Sim";

                    return View("Gerenciar_Noticias");
                }
                else
                {
                    ViewBag.Cadastrado = "Não";
                    return View("Gerenciar_Noticias");
                }
            }
        }

        public ActionResult Perfil()
        {
            return View();
        }

        public ActionResult Rendimentos()
        {
            return View("Relatorio_Rendimentos");
        }
    }
}