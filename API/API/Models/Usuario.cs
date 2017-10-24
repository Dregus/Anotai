using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Usuario
    {
        [Display(Name = "ID")]
        public int UsuarioId { get; set; }
        public string TipoUsuario { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        [Display(Name = "CEP")]
        public string Cep { get; set; }
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        [Display(Name = "Número")]
        public string NumeroCasa { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}