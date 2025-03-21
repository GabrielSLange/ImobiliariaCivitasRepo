using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace imobiliariaCivitas_shared.Model
{
    public class tb_imagem
    {
        [Key]
        public int cd_imagem { get; set; }
        public int cd_imovel { get; set; }
        public string? imageBase64 { get; set; }
        public bool is_principal { get; set; }

        [JsonIgnore]
        public tb_imovel imovel { get; set; } = new();
    }
}