using Anotai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Anotai.Controllers
{
    public class AcessosController : Controller
    {
        // GET: Acessos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Usuario u)
        {
            using (var ctx = new AnotaiContext())
            {
                if (u.Nome != null && u.Sobrenome != null && u.Email != null && u.Telefone != null && u.Senha != null)
                {
                    u.TipoUsuario = "I";
                    ctx.Usuarios.Add(u);
                    ctx.SaveChanges();
                    return RedirectToAction("Investimentos", "Investidor");
                }
                return View();
            }
        }

        public ActionResult CadastrarContato()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarContato(Usuario u)
        {
            using (var ctx = new AnotaiContext())
            {
                if (u.Nome != null && u.Sobrenome != null && u.Email != null && u.Telefone != null)
                {
                    u.TipoUsuario = "C";
                    ctx.Usuarios.Add(u);
                    ctx.SaveChanges();
                }
                return RedirectToAction("Home", "Home");
            }
        }

        public ActionResult Entrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Entrar(Usuario u)
        {
            using (var ctx = new AnotaiContext())
            {
                if (u.Email != "" && u.Senha != "")
                {
                    Usuario usuarioAutenticado = null;

                    try
                    {
                        usuarioAutenticado = ctx.Usuarios.Where(usuario =>
                            usuario.Email == u.Email &&
                            usuario.Senha == u.Senha).First();

                        if (usuarioAutenticado != null && usuarioAutenticado.TipoUsuario == "I")
                            return RedirectToAction("Investimentos", "Investidor");
                        else if (usuarioAutenticado != null && usuarioAutenticado.TipoUsuario == "A")
                            return RedirectToAction("Rendimentos", "Administrador");
                    }
                    catch (Exception e)
                    {
                        return View("Usuário ou senha inválidos: " + e.ToString());
                    }
                }
                return View("Preencha os campos");
            }
        }
    }
}