using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;

namespace API.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("ConnAPI")
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Investimento> Investimentoes { get; set; }
        public DbSet<Pacote> Pacotes { get; set; }
        public DbSet<RelatorioInvestidor> RelatorioInvestidors { get; set; }
        public DbSet<RelatorioPacote> RelatorioPacotes { get; set; }
        public DbSet<Comanda> Comandas { get; set; }

        public System.Data.Entity.DbSet<API.Models.PedidoFinalizado> PedidoFinalizadoes { get; set; }
    }
}