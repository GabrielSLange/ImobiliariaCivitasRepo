using imobiliariaCivitas_api.Data.Mappings;
using imobiliariaCivitas_shared;
using Microsoft.EntityFrameworkCore;

namespace imobiliariaCivitas_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> _options) : base(_options)
        {

        }

        public DbSet<tb_imovel> tb_imoveis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ImovelMap());
        }
    }
}