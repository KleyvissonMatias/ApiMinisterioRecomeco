using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace ApiMinisterioRecomeco.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        IService<Relatorio> _service;

        public RelatorioController(IService<Relatorio> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var relatorio = await _service.GetAllAsync();
            return Ok(relatorio);
        }

        [HttpGet]
        public async Task<IActionResult> GetPorIdAsync([FromQuery] long id)
        {
            var relatorio = await _service.GetByIdAsync(id);
            return Ok(relatorio);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Relatorio relatorio)
        {
            await _service.CreateAsync(relatorio);
            return Created($"/get-relatorio-por-id?id={relatorio.Id}", relatorio);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] Relatorio relatorioAtualizado)
        {
            await _service.UpdateAsync(relatorioAtualizado);
            return NoContent();
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
