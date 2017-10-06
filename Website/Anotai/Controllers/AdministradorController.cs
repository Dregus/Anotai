using Anotai.Models;
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
        private Repositorio db = new Repositorio();

        // GET: Administrador
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Noticia()
        {
            HomeViewModel model = new HomeViewModel();
            model.Noticias = db.ListarNoticias();

            return View("Gerenciar_Noticias", model);
        }

        public ActionResult CadastrarNoticia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarNoticia(HomeViewModel hvm)
        {
            using (var ctx = new AnotaiContext())
            {
                if (hvm.Noticia.Titulo != null && hvm.Noticia.Mensagem != null)
                {
                    db.IncluirNoticia(hvm.Noticia);

                    //Limpa model e tela
                    ModelState.Clear();

                    //Parâmetro para notificação de tela
                    ViewBag.Cadastrado = "Sim";

                    //Direciona para a tela
                    return View("Gerenciar_Noticias");
                }
                else
                {
                    //Parâmetro para notificação de tela
                    ViewBag.Cadastrado = "Não";

                    //Direciona para a tela
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