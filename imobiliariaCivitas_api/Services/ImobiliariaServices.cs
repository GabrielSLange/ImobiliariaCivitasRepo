using imobiliariaCivitas_api.Data;
using imobiliariaCivitas_shared.DTOs;
using imobiliariaCivitas_shared.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace imobiliariaCivitas_api.Services
{
    public class ImobiliariaServices
    {
        private readonly IConfiguration _configuration;
        protected AppDbContext _context;
        public ImobiliariaServices(AppDbContext context, IConfiguration configuration) 
        {
            _configuration = configuration;
            _context = context;
        }

        #region Imoveis
        public async Task<List<tb_imovel>> ObterImoveis()
        {
            return await _context.tb_imoveis.ToListAsync();
        }
        #endregion

        #region Imagem
        public async Task SalvarImagem(int cdImovel, string? imagem)
        {
            tb_imovel imovel = await _context.tb_imoveis.FirstOrDefaultAsync(tb => tb.cd_imovel == cdImovel) ?? throw new Exception($"Imovel não encontrado para o cd_imovel = {cdImovel}");
            
            if (imagem != null)
            {

                tb_imagem imagemModel = new()
                {
                    cd_imovel = cdImovel,
                    imageBase64 = imagem,
                    imovel = imovel
                };

                _context.tb_imagens.Add(imagemModel);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"A imagem não pode ser nula");
            }
            
            
        }

        public async Task<List<tb_imagem>> ObterImagemPorImovel(int cdImovel)
        {
            return await _context.tb_imagens.Where(tb => tb.cd_imovel == cdImovel).ToListAsync();
        }
        #endregion


        #region Contas
        public async Task<string> FazerLogin(LoginUsuarioDTO usuario)
        {
            tb_usuario usuarioBanco = await _context.tb_usuarios.FirstOrDefaultAsync(tb => tb.email == usuario.usuario) ?? throw new Exception("Usuario não encontrado");

            if (VerifyPassword(usuario.senha, usuarioBanco.senha))
            {
                var jwtSettings = _configuration.GetSection("JwtSettings");

                // Criação do token JWT
                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, usuarioBanco.email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: jwtSettings["Issuer"],
                    audience: jwtSettings["Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["ExpirationMinutes"])),
                    signingCredentials: creds
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            else
            {
               throw new Exception("Senha informada incorreta");
            }            
        }

        public async Task CriarConta(CriarLoginUsuarioDTO usuario)
        {
            if(usuario.cd_acesso == 0) usuario.cd_acesso = 2;

            tb_acesso acessobanco = await _context.tb_acessos.FirstOrDefaultAsync(tb => tb.cd_acesso == usuario.cd_acesso) ?? throw new Exception("Acesso inválido");

            tb_usuario usuarioBanco = new()
            {
                cd_acesso = usuario.cd_acesso,
                nome_usuario = usuario.nome_usuario,
                email = usuario.email,
                senha = usuario.senha,
                acesso = acessobanco                
            };


            usuarioBanco.acesso = acessobanco;

            usuarioBanco.senha = HashPassword(usuario.senha);

            _context.Add(usuarioBanco);
            await _context.SaveChangesAsync();
        }

        public string HashPassword(string password)
        {
            // Hashing com bcrypt, gerando um salt automaticamente
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string storedHash)
        {
            // Verifica se a senha fornecida corresponde ao hash armazenado
            return BCrypt.Net.BCrypt.Verify(password, storedHash);
        }
        #endregion
    }
}
