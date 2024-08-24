using imobiliariaCivitas_api.Data;
using imobiliariaCivitas_shared;
using Microsoft.EntityFrameworkCore;

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
    }
}
