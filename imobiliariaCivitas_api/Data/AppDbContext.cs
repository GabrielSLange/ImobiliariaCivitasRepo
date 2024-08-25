using imobiliariaCivitas_api.Data.Mappings;
using imobiliariaCivitas_shared.Model;
using Microsoft.EntityFrameworkCore;

namespace imobiliariaCivitas_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> _options) : base(_options)
        {

        }

        public DbSet<tb_imovel> tb_imoveis { get; set; }
        public DbSet<tb_imagem> tb_imagens { get; set; }
        public DbSet<tb_usuario> tb_usuarios { get; set; }
        public DbSet<tb_acesso> tb_acessos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ImovelMap());
            modelBuilder.ApplyConfiguration(new ImagensMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
    }
}