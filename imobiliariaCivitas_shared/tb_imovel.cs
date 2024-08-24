using System.ComponentModel.DataAnnotations;

namespace imobiliariaCivitas_shared
{
    public class tb_imovel
    {
        [Key]
        public int cd_imovel { get; set; }
        public string descricao { get; set; } = null!;
        public DateTime criadoEm { get; set; } = DateTime.Now;
    }
}