using ApiMinisterioRecomeco.Exception;
using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiMinisterioRecomeco.Controllers
{
    [Route("api/v1/relatorio/[action]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly RelatorioService _service;
        private readonly ILogger<Relatorio> _logger;

        private const string LOG_CONTROLLER = "RelatorioController:";

        public RelatorioController(RelatorioService service, ILogger<Relatorio> logger)
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
                _logger.LogInformation(LOG_CONTROLLER + " [Listando relatórios]");
                var relatorio = await _service.GetAllAsync();
                return Ok(relatorio);
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
                _logger.LogInformation(LOG_CONTROLLER + " [Obtendo relatório por ID]");
                var relatorio = await _service.GetByIdAsync(id);
                return Ok(relatorio);
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
        public async Task<IActionResult> PostAsync([FromBody] Relatorio relatorio)
        {
            try
            {
                _logger.LogInformation(LOG_CONTROLLER + " [Criando relatório]");
                await _service.CreateAsync(relatorio);
                return Created($"/listar-por-id?id={relatorio.Id}", relatorio);
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
        public async Task<IActionResult> PutAsync([FromBody] Relatorio relatorioAtualizado)
        {
            try
            {
                _logger.LogInformation(LOG_CONTROLLER + " [Atualizando relatório]");
                await _service.UpdateAsync(relatorioAtualizado);
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
                _logger.LogInformation(LOG_CONTROLLER + " [Deletando relatório]");
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
