using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Anotai.Models;

namespace Anotai.Controllers
{
    public class NoticiasController : Controller
    {
        private AnotaiContext db = new AnotaiContext();
        
        public ActionResult Index()
        {
            HomeViewModel hvm = new HomeViewModel();
            hvm.Noticias = db.Noticias.ToList();
            return View("Gerenciar_Noticias", hvm);
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Noticia noticia = db.Noticias.Find(id);
            if (noticia == null)
            {
                return HttpNotFound();
            }
            return View(noticia);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(HomeViewModel hvm)
        {
            using (var ctx = new AnotaiContext())
            {
                Repositorio repositorio = new Repositorio();

                if (hvm.Noticia.Titulo != null && hvm.Noticia.Mensagem != null)
                {
                    repositorio.IncluirNoticia(hvm.Noticia);

                    //Limpa model e tela
                    ModelState.Clear();

                    //Parâmetro para notificação de tela
                    ViewBag.Cadastrado = "Sim";

                    //Atualiza o model e passa para a tela
                    HomeViewModel model = new HomeViewModel();
                    model.Noticias = repositorio.ListarNoticias();

                    //Direciona para a tela
                    return View("Gerenciar_Noticias", model);
                }
                else
                {
                    //Parâmetro para notificação de tela
                    ViewBag.Cadastrado = "Não";

                    //Atualiza o model e passa para a tela
                    HomeViewModel model = new HomeViewModel();
                    model.Noticias = repositorio.ListarNoticias();

                    //Direciona para a tela
                    return View("Gerenciar_Noticias", model);
                }
            }
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Noticia noticia = db.Noticias.Find(id);
            if (noticia == null)
            {
                return HttpNotFound();
            }
            return View("Editar_Noticias", noticia);
        }
        
        [HttpPost]
        public ActionResult Edit([Bind(Include = "NoticiaId,Titulo,Mensagem")] Noticia noticia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(noticia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Editar_Noticias", noticia);
        }
        
        public ActionResult Delete(int id)
        {
            Repositorio repositorio = new Repositorio();

            //Exclui o registro e atualiza a tela
            HomeViewModel model = new HomeViewModel();
            repositorio.ExcluirNoticia(id);
            model.Noticias = repositorio.ListarNoticias();

            return View("Gerenciar_Noticias", model);
        }
        
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Noticia noticia = db.Noticias.Find(id);
            db.Noticias.Remove(noticia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Rendimentos()
        {
            return View("Relatorio_Rendimentos");
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
