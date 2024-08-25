using imobiliariaCivitas_shared.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace imobiliariaCivitas_api.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<tb_usuario>
    {
        public void Configure(EntityTypeBuilder<tb_usuario> builder)
        {
            builder.ToTable("tb_usuario");
            builder.HasKey(tb => tb.cd_usuario);
            builder.Property(tb => tb.cd_usuario)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.HasOne(tb => tb.acesso)
                .WithMany(acesso => acesso.usuarios)  // Configura a navegação inversa
                .HasForeignKey(tb => tb.cd_acesso)  // Define cd_imovel como chave estrangeira
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(tb => tb.nome_usuario)
                .IsRequired()
                .HasColumnName("nome_usuario")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.Property(tb => tb.email)
                .IsRequired()
                .HasColumnName("email")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.Property(tb => tb.senha)
                .IsRequired()
                .HasColumnName("senha")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);
        }
    }
}