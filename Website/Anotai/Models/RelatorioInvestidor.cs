using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Anotai.Models
{
    public class RelatorioInvestidor
    {
        public int RelatorioInvestidorId { get; set; }
        [Display(Name = "Nome do Investidor")]
        public string NomeInvestidor { get; set; }
        [Display(Name = "Valor Total")]
        public double ValorTotal { get; set; }
    }
}