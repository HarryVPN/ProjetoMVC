
using MeuSiteEmMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuSiteEmMVC.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) :base(options) 
        {

        }

        public DbSet<DenunciaModel> Denuncias { get; set; }
        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}
