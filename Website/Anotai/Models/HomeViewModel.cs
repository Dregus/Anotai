using Anotai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anotai.Models
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            Usuario = new Usuario();
            Noticia = new Noticia();
            Contato = new Contato();
        }

        public Noticia Noticia { get; set; }
        public Usuario Usuario { get; set; }
        public Contato Contato { get; set; }
        public IEnumerable<Noticia> Noticias { get; set; }
        public IEnumerable<Usuario> Usuarios { get; set; }
        public IEnumerable<Contato> Contatos { get; set; }
    }
}