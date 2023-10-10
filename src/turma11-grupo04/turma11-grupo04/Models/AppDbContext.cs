using Microsoft.EntityFrameworkCore;

namespace turma11_grupo04.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Cobrador> Cobrador { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Cobranca> Cobranca { get; set; }
    }
}
