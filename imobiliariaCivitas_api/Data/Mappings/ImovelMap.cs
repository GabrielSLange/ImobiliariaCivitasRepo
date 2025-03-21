using imobiliariaCivitas_shared.Model;
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
            


            builder.Property(tb => tb.descricao_abreviada)
                .IsRequired()
                .HasColumnName("descricao_abreviada")
                .HasColumnType("VARCHAR")
                .HasMaxLength(200);

            builder.Property(tb => tb.descricao_longa)
                .IsRequired()
                .HasColumnName("descricao_longa")
                .HasColumnType("TEXT");

            builder.Property(tb => tb.descricao_longa)
                .IsRequired()
                .HasColumnName("descricao_longa")
                .HasColumnType("TEXT");


            builder.Property(tb => tb.qtd_banheiros)
                .IsRequired()
                .HasColumnName("qtd_banheiros")
                .HasColumnType("INT");

            builder.Property(tb => tb.qtd_quartos)
                .IsRequired()
                .HasColumnName("qtd_quartos")
                .HasColumnType("INT");

            builder.Property(tb => tb.valor_em_reais)
                .IsRequired()
                .HasColumnName("valor_em_reais")
                .HasColumnType("DECIMAL");

        }
    }
}