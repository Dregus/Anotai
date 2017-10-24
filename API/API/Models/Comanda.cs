using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Comanda
    {
        public int ComandaId { get; set; }
        public int DonoComandaId { get; set; }
        public string Bebida { get; set; }
        public string Alimento { get; set; }
        public string Sobremesa { get; set; }
    }
}