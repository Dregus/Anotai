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
                HomeViewModel model = new HomeViewModel();
                model.Noticias = db.ListarNoticias();

                if (hvm.Usuario.Email != null && hvm.Usuario.Senha != null && hvm.Usuario.Email != "" && hvm.Usuario.Senha != "")
                {
                    Usuario usuarioAutenticado = null;

                    try
                    {
                        usuarioAutenticado = ctx.Usuarios.Where(usuario =>
                            usuario.Email == hvm.Usuario.Email &&
                            usuario.Senha == hvm.Usuario.Senha).First();

                        if (usuarioAutenticado != null && usuarioAutenticado.TipoUsuario == "I")
                        {
                            //FormsAuthentication.SetAuthCookie(usuarioAutenticado.UsuarioId.ToString(), false);
                            return RedirectToAction("Investimentos", "Investidor");
                        }
                        else if (usuarioAutenticado != null && usuarioAutenticado.TipoUsuario == "A")
                        {
                            //FormsAuthentication.SetAuthCookie(usuarioAutenticado.UsuarioId.ToString(), false);
                            return RedirectToAction("Index", "Noticias");
                        }
                        else
                        {
                            ViewBag.ErroLogin = "Usuário ou senha inválidos.";
                            return View("Home", model);
                        }
                    }
                    catch (Exception e)
                    {
                        ViewBag.ErroLogin = "Usuário ou senha inválidos.";
                        return View("Home", model);
                    }
                }

                ViewBag.ErroLogin = "Preencha os campos obrigatórios.";
                return View("Home", model);

            }
        }
    }
}