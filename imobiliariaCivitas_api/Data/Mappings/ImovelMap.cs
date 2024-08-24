using imobiliariaCivitas_shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace imobiliariaCivitas_api.Data.Mappings
{
    public class ImovelMap : IEntityTypeConfiguration<tb_imovel>
    {
        public void Configure(EntityTypeBuilder<tb_imovel> builder)
        {
            builder.ToTable("tb_imovel");

            builder.HasKey(tb => tb.cd_imovel);
            builder.Property(tb => tb.cd_imovel)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(tb => tb.descricao)
                .IsRequired()
                .HasColumnName("descricao")
                .HasColumnType("VARCHAR")
                .HasMaxLength(200);
        }
    }
}