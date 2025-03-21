using imobiliariaCivitas_shared.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace imobiliariaCivitas_api.Data.Mappings
{
    public class ImagensMap : IEntityTypeConfiguration<tb_imagem>
    {
        public void Configure(EntityTypeBuilder<tb_imagem> builder)
        {
            builder.ToTable("tb_imagem");

            builder.HasKey(tb => tb.cd_imagem);
            builder.Property(tb => tb.cd_imagem)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Configura a chave estrangeira para usar cd_imovel
            builder.HasOne(tb => tb.imovel)
                .WithMany(imovel => imovel.imagens)  // Configura a navegação inversa
                .HasForeignKey(tb => tb.cd_imovel)  // Define cd_imovel como chave estrangeira
                .OnDelete(DeleteBehavior.Cascade);


            builder.Property(tb => tb.imageBase64)
                .IsRequired()
                .HasColumnName("imageBase64")
                .HasColumnType("TEXT");

            builder.Property(tb => tb.is_principal)
                .IsRequired()
                .HasColumnName("is_principal")
                .HasColumnType("BOOLEAN");
        }
    }
}