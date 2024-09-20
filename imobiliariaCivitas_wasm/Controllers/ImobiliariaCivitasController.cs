using imobiliariaCivitas_shared.Model;
using imobiliariaCivitas_wasm.Services;
using Microsoft.AspNetCore.Mvc;

namespace imobiliariaCivitas_wasm.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ImobiliariaCivitasController : ControllerBase
    {
        private readonly ImobiliariaCivitasServices _services;
        public ImobiliariaCivitasController(ImobiliariaCivitasServices Aservices)
        {
            _services = Aservices;
        }

        [HttpGet]
        public async Task<ActionResult<List<tb_imovel>>> ObterImoveis()
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
    }
}
