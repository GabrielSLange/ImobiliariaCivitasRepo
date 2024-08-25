using imobiliariaCivitas_api.Services;
using imobiliariaCivitas_shared.DTOs;
using imobiliariaCivitas_shared.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace imobiliariaCivitas_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ImagemController : ControllerBase
    {
        private ImobiliariaServices _services;

        public ImagemController(ImobiliariaServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult<List<tb_imagem>>> ObterImagensPorImovel(int cdImovel)
        {
            try
            {
                return Ok(await _services.ObterImagemPorImovel(cdImovel));
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> SalvarImagem(ImagemDTO imagem)
        {
            try
            {
                await _services.SalvarImagem(imagem.cd_imovel, imagem.imagem);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
