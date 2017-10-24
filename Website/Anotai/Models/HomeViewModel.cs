using Anotai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anotai.Models
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            Usuario = new Usuario();
            Noticia = new Noticia();
            Contato = new Contato();
        }

        public Noticia Noticia { get; set; }
        public Usuario Usuario { get; set; }
        public Contato Contato { get; set; }
        public Pacote Pacote { get; set; }
        public Investimento Investimento { get; set; }
        public RelatorioPacote RelatorioPacote { get; set; }
        public RelatorioInvestidor RelatorioInvestidor { get; set; }
        public IEnumerable<Noticia> Noticias { get; set; }
        public IEnumerable<Usuario> Usuarios { get; set; }
        public IEnumerable<Contato> Contatos { get; set; }
        public IEnumerable<Pacote> Pacotes { get; set; }
        public IEnumerable<Investimento> Investimentos { get; set; }
        public IEnumerable<RelatorioPacote> RelatorioPacotes { get; set; }
        public IEnumerable<RelatorioInvestidor> RelatorioInvestidores { get; set; }
    }
}