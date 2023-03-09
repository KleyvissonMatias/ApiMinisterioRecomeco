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

        public RelatorioController(RelatorioService service)
        {
            _service = service;
        }

        [HttpGet]
        [ActionName("listar")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
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
                return BadRequest(responseError);
            }
            catch (System.Exception e)
            {
                Response responseError = new()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = e.Message
                };
                return StatusCode((int)HttpStatusCode.InternalServerError, responseError);
            }
        }

        [HttpGet]
        [ActionName("listar-por-id")]
        public async Task<IActionResult> GetPorIdAsync([FromQuery] Int64 id)
        {
            try
            {
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
                return BadRequest(responseError);
            }
            catch (System.Exception e)
            {
                Response responseError = new()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = e.Message
                };
                return StatusCode((int)HttpStatusCode.InternalServerError, responseError);
            }
        }

        [HttpPost]
        [ActionName("criar")]
        public async Task<IActionResult> PostAsync([FromBody] Relatorio relatorio)
        {
            try
            {
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
                return BadRequest(responseError);
            }
            catch (System.Exception e)
            {
                Response responseError = new()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = e.Message
                };
                return StatusCode((int)HttpStatusCode.InternalServerError, responseError);
            }
        }

        [HttpPut]
        [ActionName("atualizar")]
        public async Task<IActionResult> PutAsync([FromBody] Relatorio relatorioAtualizado)
        {
            try
            {
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
                return BadRequest(responseError);
            }
            catch (System.Exception e)
            {
                Response responseError = new()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = e.Message
                };
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
                return BadRequest(responseError);
            }
            catch (System.Exception e)
            {
                Response responseError = new()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = e.Message
                };
                return StatusCode((int)HttpStatusCode.InternalServerError, responseError);
            }
        }
    }
}
