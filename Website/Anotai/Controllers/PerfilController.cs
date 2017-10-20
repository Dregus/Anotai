using Anotai.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Anotai.Controllers
{
    public class PerfilController : Controller
    {
        private AnotaiContext db = new AnotaiContext();
        private Repositorio repositorio = new Repositorio();

        public ActionResult Perfil()
        {
            getMensagem();
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (Request.Cookies.Get("usuarioLogado").Value != null)
                id = int.Parse(Request.Cookies.Get("usuarioLogado").Value);

            Usuario usuario = db.Usuarios.Find(id);

            getMensagem();
            return View("Perfil", usuario);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "UsuarioId,TipoUsuario,Nome,Sobrenome,Telefone,Cep,Endereco,NumeroCasa,Email,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();

                //Parâmetro para notificação de tela
                ViewBag.Atualizado = "Sim";

                getMensagem();
                return View("Perfil", usuario);
            }

            getMensagem();
            return View("Perfil", usuario);
        }

        protected void getMensagem()
        {
            if (Request.Cookies.Get("usuarioLogado") != null)
            {
                string id = Request.Cookies.Get("usuarioLogado").Value;
                Usuario resultado = repositorio.GetNomeUsuario(int.Parse(id));
                ViewBag.UsuarioLogado = resultado.Nome;
            }
        }
    }
}