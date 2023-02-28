﻿using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMinisterioRecomeco.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class VidaController : ControllerBase
    {
        private readonly IService<Vida> _service;

        public VidaController(IService<Vida> service)
        {
            _service = service;
        }

        [HttpGet]
        [ActionName("Listar")]
        public async Task<IActionResult> GetAllAsync()
        {
            var vidas = await _service.GetAllAsync();
            return Ok(vidas);
        }

        [HttpGet]
        [ActionName("ListarPorId")]
        public async Task<IActionResult> GetPorIdAsync([FromQuery] Int64 id)
        {
            var vida = await _service.GetByIdAsync(id);
            return Ok(vida);
        }

        [HttpPost]
        [ActionName("Criar")]
        public async Task<IActionResult> PostAsync([FromBody] Vida vida)
        {
            await _service.CreateAsync(vida);
            return Created($"/get-listar-por-id?id={vida.Id}", vida);
        }

        [HttpPut]
        [ActionName("Atualizar")]
        public async Task<IActionResult> PutAsync([FromBody] Vida vidaAtualizado)
        {
            await _service.UpdateAsync(vidaAtualizado);
            return NoContent();
        }

        [Route("{id}")]
        [HttpDelete]
        [ActionName("Deletar")]
        public async Task<IActionResult> DeleteAsync(Int64 id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
