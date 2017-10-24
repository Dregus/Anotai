using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Investimento
    {
        public int InvestimentoId { get; set; }
        public int IdUsuario { get; set; }
        public int IdPacote { get; set; }
        public int Quantidade { get; set; }
    }
}