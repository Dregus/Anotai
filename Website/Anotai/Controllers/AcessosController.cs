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
        public ActionResult Cadastrar(HomeViewModel hvm)
        {
            using (var ctx = new AnotaiContext())
            {
                if (hvm.Usuario.Nome != null && hvm.Usuario.Sobrenome != null && hvm.Usuario.Email != null && hvm.Usuario.Telefone != null && hvm.Usuario.Senha != null)
                {
                    hvm.Usuario.TipoUsuario = "I";
                    ctx.Usuarios.Add(hvm.Usuario);
                    ctx.SaveChanges();
                    return RedirectToAction("Investimentos", "Investidor");
                } else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
                return RedirectToAction("Home", "Home");
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
        public ActionResult Entrar(HomeViewModel hvm)
        {
            using (var ctx = new AnotaiContext())
            {
                if (hvm.Usuario.Email != "" && hvm.Usuario.Senha != "")
                {
                    Usuario usuarioAutenticado = null;

                    try
                    {
                        usuarioAutenticado = ctx.Usuarios.Where(usuario =>
                            usuario.Email == hvm.Usuario.Email &&
                            usuario.Senha == hvm.Usuario.Senha).First();

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