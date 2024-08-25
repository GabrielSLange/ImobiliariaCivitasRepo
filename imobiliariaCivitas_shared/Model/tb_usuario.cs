using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace imobiliariaCivitas_shared.Model
{
    public class tb_usuario
    {
        [Key]
        [JsonIgnore]
        public int cd_usuario { get; set; }
        public int cd_acesso { get; set; }
        public string nome_usuario { get; set; } = null!;
        public string email { get; set; } = null!;
        public string senha { get; set; } = null!;

        [JsonIgnore]
        public tb_acesso acesso { get; set; } = new();
    }
}