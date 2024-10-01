using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace imobiliariaCivitas_shared.Model
{
    public class tb_imovel
    {
        [Key]
        public int cd_imovel { get; set; }
        public string descricao { get; set; } = null!;
        public DateTime criadoEm { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        public List<tb_imagem> imagens { get; set; } = new();
    }
}