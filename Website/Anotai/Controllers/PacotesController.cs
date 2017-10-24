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
    public class PacotesController : Controller
    {
        private AnotaiContext db = new AnotaiContext();
        private Repositorio repositorio = new Repositorio();

        public ActionResult Index()
        {
            HomeViewModel hvm = new HomeViewModel();
            hvm.Pacotes = db.Pacotes.ToList();
            
            getMensagem();
            return View("Gerenciar_Pacotes", hvm);
        }

        public ActionResult Details(int? id)
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
            return View(pacote);
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

                if (hvm.Pacote.Titulo != null && hvm.Pacote.Descricao != null && hvm.Pacote.Preco.ToString() != null && hvm.Pacote.QtdDisponivel.ToString() != null)
                {
                    hvm.Pacote.QtdDisponivel = hvm.Pacote.QtdTotal;

                    db.Pacotes.Add(hvm.Pacote);
                    db.SaveChanges();

                    //Limpa model e tela
                    ModelState.Clear();

                    //Parâmetro para notificação de tela
                    ViewBag.Cadastrado = "Sim";

                    //Atualiza o model e passa para a tela
                    HomeViewModel model = new HomeViewModel();
                    model.Pacotes = db.Pacotes.ToList();

                    getMensagem();

                    //Direciona para a tela
                    return View("Gerenciar_Pacotes", model);
                }
                else
                {
                    //Parâmetro para notificação de tela
                    ViewBag.Cadastrado = "Não";

                    //Atualiza o model e passa para a tela
                    HomeViewModel model = new HomeViewModel();
                    model.Pacotes = db.Pacotes.ToList();

                    getMensagem();

                    //Direciona para a tela
                    return View("Gerenciar_Pacotes", model);
                }
            }
        }

        public ActionResult Edit(int? id)
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
            return View("Editar_Pacotes", pacote);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "PacoteId,Titulo,Descricao,Preco,QtdTotal")] Pacote pacote)
        {
            if (ModelState.IsValid)
            {
                pacote.QtdDisponivel = pacote.QtdTotal;
                db.Entry(pacote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            getMensagem();
            return View("Editar_Pacotes", pacote);
        }

        public ActionResult Delete(int id)
        {
            Repositorio repositorio = new Repositorio();

            //Exclui o registro e atualiza a tela
            HomeViewModel model = new HomeViewModel();
            repositorio.ExcluirPacote(id);
            model.Pacotes = db.Pacotes.ToList();

            getMensagem();
            return View("Gerenciar_Pacotes", model);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Pacote pacote = db.Pacotes.Find(id);
            db.Pacotes.Remove(pacote);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult PesquisarPacotes(HomeViewModel hvm)
        {
            HomeViewModel model = new HomeViewModel();

            if (hvm != null)
                model.Pacotes = repositorio.PesquisarPacote(hvm);
            else
                model.Pacotes = db.Pacotes.ToList();

            getMensagem();
            return View("Relatorios", model);
        }

        public ActionResult Relatorios()
        {
            HomeViewModel model = new HomeViewModel();
            model.Pacotes = db.Pacotes.ToList();

            //Lógica para relatório por Investidor
            List<Usuario> usuarios = db.Usuarios.ToList();
            List<Investimento> investimentos = db.Investimentos.ToList();
            List<RelatorioInvestidor> relatorioInvestidor = db.RelatorioInvestidores.ToList();
            double viewbagValor = 0;

            for (int i = 0; i < usuarios.Count(); i++)
            {
                RelatorioInvestidor ri = new RelatorioInvestidor();
                ri.NomeInvestidor = usuarios.ElementAt(i).Nome + " " + usuarios.ElementAt(i).Sobrenome;
                double totalInvestimentos = 0;

                for (int j = 0; j < investimentos.Count(); j++)
                {
                    if (investimentos.ElementAt(j).IdUsuario == usuarios.ElementAt(i).UsuarioId)
                    {
                        Pacote pacote = db.Pacotes.Find(investimentos.ElementAt(j).IdPacote);
                        totalInvestimentos = totalInvestimentos + (investimentos.ElementAt(j).Quantidade * pacote.Preco);
                        viewbagValor = viewbagValor + (investimentos.ElementAt(j).Quantidade * pacote.Preco);
                    }
                }

                ri.ValorTotal = totalInvestimentos;
                relatorioInvestidor.Add(ri);
            }

            //Lógica para relatório por Pacote
            List<Pacote> pacotes = db.Pacotes.ToList();
            List<RelatorioPacote> relatoriosPacotes = db.RelatorioPacotes.ToList();

            for (int i = 0; i < pacotes.Count(); i++)
            {
                RelatorioPacote rp = new RelatorioPacote();
                rp.NomePacote = pacotes.ElementAt(i).Titulo;
                double totalInvestimentos = 0;

                for (int j = 0; j < investimentos.Count(); j++)
                {
                    if (investimentos.ElementAt(j).IdPacote == pacotes.ElementAt(i).PacoteId)
                    {
                        totalInvestimentos = totalInvestimentos + (investimentos.ElementAt(j).Quantidade * pacotes.ElementAt(i).Preco);
                    }
                }

                rp.ValorTotal = totalInvestimentos;
                relatoriosPacotes.Add(rp);
            }

            model.RelatorioInvestidores = relatorioInvestidor;
            model.RelatorioPacotes = relatoriosPacotes;

            ViewBag.ValorTotal = viewbagValor;
            getMensagem();
            return View(model);
        }

        public ActionResult PesquisarPorPacote(HomeViewModel model)
        {
            model.Pacotes = db.Pacotes.ToList();

            //Lógica para relatório por Investidor
            List<Usuario> usuarios = db.Usuarios.ToList();
            List<Investimento> investimentos = db.Investimentos.ToList();
            List<RelatorioInvestidor> relatorioInvestidor = db.RelatorioInvestidores.ToList();

            for (int i = 0; i < usuarios.Count(); i++)
            {
                RelatorioInvestidor ri = new RelatorioInvestidor();
                ri.NomeInvestidor = usuarios.ElementAt(i).Nome + " " + usuarios.ElementAt(i).Sobrenome;
                double totalInvestimentos = 0;

                for (int j = 0; j < investimentos.Count(); j++)
                {
                    if (investimentos.ElementAt(j).IdUsuario == usuarios.ElementAt(i).UsuarioId)
                    {
                        Pacote pacote = db.Pacotes.Find(investimentos.ElementAt(j).IdPacote);
                        totalInvestimentos = totalInvestimentos + (investimentos.ElementAt(j).Quantidade * pacote.Preco);
                    }
                }

                ri.ValorTotal = totalInvestimentos;
                relatorioInvestidor.Add(ri);
            }

            //Lógica para relatório por Pacote
            List<Pacote> pacotes = db.Pacotes.ToList();
            List<RelatorioPacote> relatoriosPacotes = db.RelatorioPacotes.ToList();

            if (model.RelatorioPacote.NomePacote == null || model.RelatorioPacote.NomePacote == "")
            {
                for (int i = 0; i < pacotes.Count(); i++)
                {
                    RelatorioPacote rp = new RelatorioPacote();
                    rp.NomePacote = pacotes.ElementAt(i).Titulo;
                    double totalInvestimentos = 0;

                    for (int j = 0; j < investimentos.Count(); j++)
                    {
                        if (investimentos.ElementAt(j).IdPacote == pacotes.ElementAt(i).PacoteId)
                        {
                            totalInvestimentos = totalInvestimentos + (investimentos.ElementAt(j).Quantidade * pacotes.ElementAt(i).Preco);
                        }
                    }

                    rp.ValorTotal = totalInvestimentos;
                    relatoriosPacotes.Add(rp);
                }
            } else
            {
                for (int i = 0; i < pacotes.Count(); i++)
                {
                    if (pacotes.ElementAt(i).Titulo.Equals(model.RelatorioPacote.NomePacote)) {
                        RelatorioPacote rp = new RelatorioPacote();
                        rp.NomePacote = pacotes.ElementAt(i).Titulo;
                        double totalInvestimentos = 0;

                        for (int j = 0; j < investimentos.Count(); j++)
                        {
                            if (investimentos.ElementAt(j).IdPacote == pacotes.ElementAt(i).PacoteId)
                            {
                                totalInvestimentos = totalInvestimentos + (investimentos.ElementAt(j).Quantidade * pacotes.ElementAt(i).Preco);
                            }
                        }

                        rp.ValorTotal = totalInvestimentos;
                        relatoriosPacotes.Add(rp);
                    }
                }
            }

            model.RelatorioInvestidores = relatorioInvestidor;
            model.RelatorioPacotes = relatoriosPacotes;

            getMensagem();
            return View("Relatorios", model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
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
