using ApiMinisterioRecomeco.Exception;
using ApiMinisterioRecomeco.Infrastructure;
using ApiMinisterioRecomeco.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ApiMinisterioRecomeco.Services
{
    public class CelulaService : IService<Celula>
    {
        private readonly ICelulaRepository _celulaRepository;
        private readonly ILogger<Celula> _logger;

        private const string ERRO_INTERNO = "Ocorreu um erro Interno.";
        private const string ELEMENTO_NAO_ENCONTRADO = "Elemento não encontrado.";

        public CelulaService(ICelulaRepository celulaRepository, ILogger<Celula> logger)
        {
            _celulaRepository = celulaRepository;
            _logger = logger;
        }

        public async Task CreateAsync(Celula item)
        {
            try
            {
                await _celulaRepository.CreateAsync(item);
            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(HttpStatusCode.InternalServerError, ERRO_INTERNO, ex);
            }
        }

        public async Task DeleteAsync(long id)
        {
            try
            {
                var celula = await GetByIdAsync(id) ?? throw new MinisterioRecomecoException(HttpStatusCode.NotFound, ELEMENTO_NAO_ENCONTRADO);
                await _celulaRepository.DeleteAsync(celula);
            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(HttpStatusCode.InternalServerError, ERRO_INTERNO, ex);
            }
        }

        public async Task<List<Celula>> GetAllAsync()
        {
            try
            {
                return await _celulaRepository.GetAllAsync();
            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(HttpStatusCode.InternalServerError, ERRO_INTERNO, ex);
            }
        }

        public async Task<Celula> GetByIdAsync(long id)
        {
            try
            {
                return await _celulaRepository.GetByIdAsync(id) ?? throw new MinisterioRecomecoException(HttpStatusCode.NotFound, ELEMENTO_NAO_ENCONTRADO);
            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(HttpStatusCode.InternalServerError, ERRO_INTERNO, ex);
            }
        }

        public async Task UpdateAsync(Celula item)
        {
            try
            {
                await _celulaRepository.UpdateAsync(item);
            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(HttpStatusCode.InternalServerError, ERRO_INTERNO, ex);
            }
        }
    }
}
