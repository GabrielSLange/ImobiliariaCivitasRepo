using imobiliariaCivitas_api.Services;
using imobiliariaCivitas_shared.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace imobiliariaCivitas_api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ImovelController : ControllerBase
    {
        private ImobiliariaServices _services;

        public ImovelController(ImobiliariaServices services)
        {
            _services = services;
        }

        [HttpGet]
        public ActionResult<List<tb_imovel>> GetImovelTeste()
        {
            try
            {
                return Ok(_services.ObterImoveisTeste());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<tb_imovel>>> GetImovelImagens()
        {
            try
            {
                return Ok(await _services.ObterImovelImagens());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<tb_imovel>>> GetImovel()
        {
            try
            {
                return Ok(await _services.ObterImoveis());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> CriarImovel(tb_imovel imovel)
        {
            try
            {                ;
                return Ok(await _services.CriarImovel(imovel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
