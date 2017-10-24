using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class AppContext : DbContext
    {
        public AppContext() : base("ConnAPI")
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Pacote> Pacotes { get; set; }
        public DbSet<Investimento> Investimentos { get; set; }
        public DbSet<RelatorioInvestidor> RelatorioInvestidores { get; set; }
        public DbSet<RelatorioPacote> RelatorioPacotes { get; set; }
        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<PedidoFinalizado> PedidoFinalizados { get; set; }
    }

   
}