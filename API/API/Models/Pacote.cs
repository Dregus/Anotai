using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Pacote
    {
        [Display(Name = "ID")]
        public int PacoteId { get; set; }
        public string Titulo { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Preço")]
        public double Preco { get; set; }
        [Display(Name = "Quantidade Total")]
        public int QtdTotal { get; set; }
        [Display(Name = "Quantidade Disponível")]
        public int QtdDisponivel { get; set; }
        public int QtdInvestir { get; set; }
    }
}