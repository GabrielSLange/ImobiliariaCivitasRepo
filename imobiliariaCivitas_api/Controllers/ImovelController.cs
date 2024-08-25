using imobiliariaCivitas_api.Services;
using imobiliariaCivitas_shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace imobiliariaCivitas_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImovelController : ControllerBase
    {
        private ImobiliariaServices _services;

        public ImovelController(ImobiliariaServices services)
        {
            _services = services;
        }


        [HttpGet]
        public async Task<ActionResult<List<tb_imovel>>> GetImovel()
        {
            try
            {
                return Ok( await _services.ObterImoveis());          
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
