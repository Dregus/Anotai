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
            ViewData.Clear();

            // limpa usuário logado
            HttpCookie cookie = new HttpCookie("usuarioLogado");

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

                HomeViewModel model = new HomeViewModel();
                model.Noticias = db.ListarNoticias();

                if (hvm.Usuario.Nome != null && hvm.Usuario.Sobrenome != null && hvm.Usuario.Email != null && hvm.Usuario.Telefone != null && hvm.Usuario.Senha != null)
                {
                    hvm.Usuario.TipoUsuario = "I";
                    ctx.Usuarios.Add(hvm.Usuario);
                    ctx.SaveChanges();

                    // cria cookie para utilizar usuário logado
                    HttpCookie cookie = new HttpCookie("usuarioLogado");
                    cookie.Path = "/";
                    cookie.Value = hvm.Usuario.UsuarioId.ToString();
                    cookie.Expires = DateTime.Now.AddMinutes(10d);
                    Response.Cookies.Add(cookie);

                    return RedirectToAction("Investimentos", "Investidor");
                } else
                {
                    ViewBag.CadastrarErro = "Por favor, preencha todos os campos e tente novamente.";
                    return View("Home", model);
                }
            }
        }

        public ActionResult CadastrarContato()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarContato(HomeViewModel hvm)
        {
            using (var ctx = new AnotaiContext())
            {

                HomeViewModel model = new HomeViewModel();
                model.Noticias = db.ListarNoticias();

                if (hvm.Contato.Nome != null && hvm.Contato.Sobrenome != null && hvm.Contato.Email != null && hvm.Contato.Telefone != null && hvm.Contato.Mensagem != null)
                {
                    ctx.Contatos.Add(hvm.Contato);
                    ctx.SaveChanges();

                    ViewBag.ContatoOk = "Sua mensagem foi enviada com sucesso.";

                    //Limpa model e tela
                    ModelState.Clear();

                    return View("Home", model);
                } else
                {
                    ViewBag.ContatoErro = "Por favor, preencha todos os campos antes de enviar a mensagem.";

                    return View("Home", model);
                }
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
                            // cria cookie para utilizar usuário logado
                            HttpCookie cookie = new HttpCookie("usuarioLogado");
                            cookie.Path = "/";
                            cookie.Value = usuarioAutenticado.UsuarioId.ToString();
                            cookie.Expires = DateTime.Now.AddMinutes(10d);
                            Response.Cookies.Add(cookie);

                            return RedirectToAction("Investimentos", "Investidor");
                        }
                        else if (usuarioAutenticado != null && usuarioAutenticado.TipoUsuario == "A")
                        {
                            // cria cookie para utilizar usuário logado
                            HttpCookie cookie = new HttpCookie("usuarioLogado");
                            cookie.Path = "/";
                            cookie.Value = usuarioAutenticado.UsuarioId.ToString();
                            cookie.Expires = DateTime.Now.AddMinutes(10d);
                            Response.Cookies.Add(cookie);

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