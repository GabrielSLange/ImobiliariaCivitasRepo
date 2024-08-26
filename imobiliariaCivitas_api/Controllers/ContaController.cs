using imobiliariaCivitas_api.Services;
using imobiliariaCivitas_shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace imobiliariaCivitas_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaController : ControllerBase
    {
        private ImobiliariaServices _services;

        public ContaController(ImobiliariaServices services)
        {
            _services = services;
        }

        [HttpPost("/login")]
        public async Task<ActionResult> FazerLogin([FromBody]LoginUsuarioDTO usuario)
        {
            try
            {
                string Token = await _services.FazerLogin(usuario);
                if (Token != null)
                {
                    return Ok(new { Token });
                }
                else
                {
                    return BadRequest("Erro ao gerar o Token");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("/criarConta")]
        public async Task<ActionResult> CriarConta(CriarLoginUsuarioDTO usuario)
        {
            try
            {
                await _services.CriarConta(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}