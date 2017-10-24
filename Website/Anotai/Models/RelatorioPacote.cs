using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Anotai.Models
{
    public class RelatorioPacote
    {
        public int RelatorioPacoteId { get; set; }
        [Display(Name = "Nome do Pacote")]
        public string NomePacote { get; set; }
        [Display(Name = "Valor Total")]
        public double ValorTotal { get; set; }
    }
}