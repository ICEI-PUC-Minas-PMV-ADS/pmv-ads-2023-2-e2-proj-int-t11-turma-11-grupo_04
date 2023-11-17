using Microsoft.EntityFrameworkCore;

namespace Projeto_Eixo_2.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cobrador> Cobradores { get; set; }

        public DbSet<Cliente> Clientes { get; set; }
        
        public DbSet<Cobranca> Cobranca { get; set; }
    }
}
