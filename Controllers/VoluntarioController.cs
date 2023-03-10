using ApiMinisterioRecomeco.Exception;
using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace ApiMinisterioRecomeco.Controllers
{
    [Route("api/v1/voluntario/[action]")]
    [ApiController]
    public class VoluntarioController : ControllerBase
    {
        private readonly VoluntarioService _service;
        private readonly ILogger<Voluntario> _logger;

        private const string LOG_CONTROLLER = "VoluntarioController:";

        public VoluntarioController(VoluntarioService service, ILogger<Voluntario> logger)
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
                _logger.LogInformation(LOG_CONTROLLER + " [Listando voluntários]");
                var voluntarios = await _service.GetAllAsync();
                return Ok(voluntarios);
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
                _logger.LogInformation(LOG_CONTROLLER + " [Listando voluntário por ID]");
                var voluntario = await _service.GetByIdAsync(id);
                return Ok(voluntario);
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
        public async Task<IActionResult> PostAsync([FromBody] Voluntario voluntario)
        {
            try
            {
                _logger.LogInformation(LOG_CONTROLLER + " [Criando voluntário] - [{}]", JsonSerializer.Serialize(voluntario));
                await _service.CreateAsync(voluntario);
                return Created($"/listar-por-id?id={voluntario.Id}", voluntario);
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
        public async Task<IActionResult> PutAsync([FromBody] Voluntario voluntarioAtualizado)
        {
            try
            {
                _logger.LogInformation(LOG_CONTROLLER + " [Atualizando voluntário] - [{}]", JsonSerializer.Serialize(voluntarioAtualizado));
                await _service.UpdateAsync(voluntarioAtualizado);
                return NoContent(); ;
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
                _logger.LogInformation(LOG_CONTROLLER + " [Deletando voluntário]");
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
