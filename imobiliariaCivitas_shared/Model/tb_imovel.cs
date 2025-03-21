using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace imobiliariaCivitas_shared.Model
{
    public class tb_imovel
    {
        [Key]
        public int cd_imovel { get; set; }
        public string? descricao_abreviada { get; set; }
        public string? descricao_longa { get; set; }
        public int qtd_banheiros { get; set; }
        public int qtd_quartos { get; set; }

        public decimal valor_em_reais { get; set; }

        public DateTime criadoEm { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        public List<tb_imagem> imagens { get; set; } = new();
    }
}