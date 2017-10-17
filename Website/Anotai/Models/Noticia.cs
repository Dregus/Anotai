using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Anotai.Models
{
    public class Noticia
    {
        [Display(Name = "ID")]
        public int NoticiaId { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
    }
}