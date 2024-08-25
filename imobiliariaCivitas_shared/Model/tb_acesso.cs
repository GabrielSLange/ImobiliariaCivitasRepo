using System.ComponentModel.DataAnnotations;

namespace imobiliariaCivitas_shared.Model
{
    public class tb_acesso
    {
        [Key]
        public int cd_acesso { get; set; }
        public string tipo_acesso { get; set; } = null!;

        public List<tb_usuario> usuarios { get; set; } = new();
    }
}
