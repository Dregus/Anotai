using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Anotai.Models
{
    public class Usuario
    {
        [Key]
        public int    Id         { get; set; }
        public string Nome       { get; set; }
        public string Sobrenome  { get; set; }
        public string Telefone   { get; set; }
        public string TipoUsario { get; set; }
        public string Email      { get; set; }
        public string Senha      { get; set; }
    }
}