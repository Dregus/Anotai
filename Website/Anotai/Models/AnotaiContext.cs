using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Anotai.Models
{
    public class AnotaiContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Pacote> Pacotes { get; set; }
        public DbSet<Investimento> Investimentos { get; set; }
        public DbSet<RelatorioInvestidor> RelatorioInvestidores { get; set; }
        public DbSet<RelatorioPacote> RelatorioPacotes { get; set; }
    }
}