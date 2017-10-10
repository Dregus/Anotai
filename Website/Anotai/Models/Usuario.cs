using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Anotai.Models
{
    public class Usuario
    {
        //public Usuario(string Nome, string Sobrenome, string Telefone, string TipoUsuario, string Email, string Senha)
        //{
        //  this.Nome = Nome;
        //  this.Sobrenome = Sobrenome;
        //  this.Telefone = Telefone;
        //  this.TipoUsuario = TipoUsuario;
        //  this.Email = Email;
        //  this.Senha = Senha;
        //}

        [Display(Name = "ID")]
        public int    UsuarioId   { get; set; }
        [Required]
        public string Nome        { get; set; }
        [Required]
        public string Sobrenome   { get; set; }
        public string Telefone    { get; set; }
        [Required]
        public string TipoUsuario { get; set; }
        [Required]
        public string Email       { get; set; }
        [Required]
        public string Senha       { get; set; }
    }
}