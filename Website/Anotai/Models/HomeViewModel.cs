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
        }

        public Noticia Noticia { get; set; }
        public Usuario Usuario { get; set; }
        public IEnumerable<Noticia> Noticias { get; set; }
    }
}