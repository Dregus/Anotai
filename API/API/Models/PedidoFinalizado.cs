using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class PedidoFinalizado
    {
        public int PedidoFinalizadoId { get; set; }
        public int DonoComandaId { get; set; }
        public int NumeroComanda { get; set; }
        public double ValorTotal { get; set; }
    }
}