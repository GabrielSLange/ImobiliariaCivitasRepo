using imobiliariaCivitas_api.Data;
using imobiliariaCivitas_shared.Model;
using Microsoft.EntityFrameworkCore;
using System.Drawing;


namespace imobiliariaCivitas_api.Services
{
    public class ImobiliariaServices
    {
        protected AppDbContext _context;
        public ImobiliariaServices(AppDbContext context) 
        {
            _context = context;
        }

        #region
        public async Task<List<tb_imovel>> ObterImoveis()
        {
            return await _context.tb_imoveis.ToListAsync();
        }
        #endregion

        #region
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
    }
}
