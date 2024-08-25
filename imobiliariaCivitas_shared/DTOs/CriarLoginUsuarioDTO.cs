namespace imobiliariaCivitas_shared.DTOs
{
    public class CriarLoginUsuarioDTO
    {
        public int cd_acesso { get; set; }
        public string nome_usuario { get; set; } = null!;
        public string email { get; set; } = null!;
        public string senha { get; set; } = null!;
    }
}
