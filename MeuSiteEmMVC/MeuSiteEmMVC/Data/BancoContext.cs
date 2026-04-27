
using MeuSiteEmMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuSiteEmMVC.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) :base(options) 
        {

        }

        public DbSet<ContatoModel> Contato { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}
