using ApiMinisterioRecomeco.Exception;
using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace ApiMinisterioRecomeco.Controllers
{
    [Route("api/v1/vida/[action]")]
    [ApiController]
    public class VidaController : ControllerBase
    {
        private readonly VidaService _service;
        private readonly ILogger<Vida> _logger;

        private const string LOG_CONTROLLER = "VidaController:";

        public VidaController(VidaService service, ILogger<Vida> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [ActionName("listar")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                _logger.LogInformation(LOG_CONTROLLER + " [Listando vidas]");
                var vidas = await _service.GetAllAsync();
                return Ok(vidas);
            }
            catch (MinisterioRecomecoException ex)
            {
                Response responseError = new()
                {
                    StatusCode = (HttpStatusCode)ex._httpStatusCode,
                    Message = ex._message
                };

                _logger.LogError(ex, LOG_CONTROLLER + " [{}]", ex._message);
                return BadRequest(responseError);
            }
            catch (System.Exception e)
            {
                Response responseError = new()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = e.Message
                };

                _logger.LogError(e, LOG_CONTROLLER + " [{}]", e.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, responseError);
            }
        }

        [HttpGet]
        [ActionName("listar-por-id")]
        public async Task<IActionResult> GetPorIdAsync([FromQuery] Int64 id)
        {
            try
            {
                _logger.LogInformation(LOG_CONTROLLER + " [Obtendo vida por ID]");
                var vida = await _service.GetByIdAsync(id);
                return Ok(vida);
            }
            catch (MinisterioRecomecoException ex)
            {
                Response responseError = new()
                {
                    StatusCode = (HttpStatusCode)ex._httpStatusCode,
                    Message = ex._message
                };

                _logger.LogError(ex, LOG_CONTROLLER + " [{}]", ex._message);
                return BadRequest(responseError);
            }
            catch (System.Exception e)
            {
                Response responseError = new()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = e.Message
                };

                _logger.LogError(e, LOG_CONTROLLER + " [{}]", e.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, responseError);
            }
        }

        [HttpPost]
        [ActionName("criar")]
        public async Task<IActionResult> PostAsync([FromBody] Vida vida)
        {
            try
            {
                _logger.LogInformation(LOG_CONTROLLER + " [Criando vida] - [{}]", JsonSerializer.Serialize(vida));
                await _service.CreateAsync(vida);
                return Created($"/listar-por-id?id={vida.Id}", vida);
            }
            catch (MinisterioRecomecoException ex)
            {
                Response responseError = new()
                {
                    StatusCode = (HttpStatusCode)ex._httpStatusCode,
                    Message = ex._message
                };

                _logger.LogError(ex, LOG_CONTROLLER + " [{}]", ex._message);
                return BadRequest(responseError);
            }
            catch (System.Exception e)
            {
                Response responseError = new()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = e.Message
                };

                _logger.LogError(e, LOG_CONTROLLER + " [{}]", e.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, responseError);
            }
        }

        [HttpPut]
        [ActionName("atualizar")]
        public async Task<IActionResult> PutAsync([FromBody] Vida vidaAtualizado)
        {
            try
            {
                _logger.LogInformation(LOG_CONTROLLER + " [Atualizando vida] - [{}]", JsonSerializer.Serialize(vidaAtualizado));
                await _service.UpdateAsync(vidaAtualizado);
                return NoContent();
            }
            catch (MinisterioRecomecoException ex)
            {
                Response responseError = new()
                {
                    StatusCode = (HttpStatusCode)ex._httpStatusCode,
                    Message = ex._message
                };

                _logger.LogError(ex, LOG_CONTROLLER + " [{}]", ex._message);
                return BadRequest(responseError);
            }
            catch (System.Exception e)
            {
                Response responseError = new()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = e.Message
                };

                _logger.LogError(e, LOG_CONTROLLER + " [{}]", e.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, responseError);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        [ActionName("deletar")]
        public async Task<IActionResult> DeleteAsync(Int64 id)
        {
            try
            {
                _logger.LogInformation(LOG_CONTROLLER + " [Deletando vida]");
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (MinisterioRecomecoException ex)
            {
                Response responseError = new()
                {
                    StatusCode = (HttpStatusCode)ex._httpStatusCode,
                    Message = ex._message
                };

                _logger.LogError(ex, LOG_CONTROLLER + " [{}]", ex._message);
                return BadRequest(responseError);
            }
            catch (System.Exception e)
            {
                Response responseError = new()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = e.Message
                };

                _logger.LogError(e, LOG_CONTROLLER + " [{}]", e.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, responseError);
            }
        }
    }
}
