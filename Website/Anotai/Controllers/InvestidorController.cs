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
    public class InvestidorController : Controller
    {
        private AnotaiContext db = new AnotaiContext();
        private Repositorio repositorio = new Repositorio();

        // GET: Investidor
        public ActionResult Index()
        {
            HomeViewModel hvm = new HomeViewModel();
            hvm.Pacotes = db.Pacotes.ToList();

            getMensagem();
            return View("Investir", hvm);
        }

        public ActionResult Investir(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacote pacote = db.Pacotes.Find(id);
            if (pacote == null)
            {
                return HttpNotFound();
            }

            getMensagem();
            return View("Confirmar_Investimento", pacote);
        }

        [HttpPost]
        public ActionResult Investir([Bind(Include = "PacoteId,Titulo,Descricao,Preco,QtdDisponivel,QtdInvestir")] Pacote pacote)
        {
            if ((pacote.QtdDisponivel - pacote.QtdInvestir) > 0)
            {
                ViewBag.Ok = "X";
                ViewBag.DescOk = "Você investiu neste pacote.";
                pacote.QtdDisponivel = pacote.QtdDisponivel - pacote.QtdInvestir;
                db.Entry(pacote).State = EntityState.Modified;
                
                Investimento investimento = new Investimento();
                investimento.IdUsuario = int.Parse(Request.Cookies.Get("usuarioLogado").Value);
                investimento.IdPacote = pacote.PacoteId;
                investimento.Quantidade = pacote.QtdInvestir;
                db.Investimentos.Add(investimento);

                db.SaveChanges();
            } else
            {
                ViewBag.Erro = "X";
                ViewBag.DescErro = "Pacote não possui disponibilidade para investimento.";
            }

            HomeViewModel hvm = new HomeViewModel();
            hvm.Pacotes = db.Pacotes.ToList();

            getMensagem();
            return View("Investir", hvm);
        }

        public ActionResult Perfil()
        {
            return View();
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