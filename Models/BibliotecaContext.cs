using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ProjMaster.Models
{
    public class BibliotecaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {                   
            optionsBuilder.UseMySql("Server=localhost;DataBase=MasterPizza;Uid=root;");
        }
        public DbSet<Usuario> usuarios {get; set;}
    }
}