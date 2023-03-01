using ApiMinisterioRecomeco.Exception;
using ApiMinisterioRecomeco.Infrastructure;
using ApiMinisterioRecomeco.Models;
using static ApiMinisterioRecomeco.Constants.Errors;
using System.Net;

namespace ApiMinisterioRecomeco.Services
{
    public class CelulaService : IService<Celula>
    {
        private readonly ICelulaRepository _celulaRepository;
        private readonly ILogger<Celula> _logger;

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
                throw new MinisterioRecomecoException(ex._httpStatusCode, ex._message, ex);
            }
        }

        public async Task DeleteAsync(Int64 id)
        {
            try
            {
                var celula = await GetByIdAsync(id) ?? await Task.FromResult<Celula>(null);
                var celulaDelete = celula ?? throw new MinisterioRecomecoException(HttpStatusCode.NotFound, ELEMENTO_NAO_ENCONTRADO);
                await _celulaRepository.DeleteAsync(celulaDelete);
            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(ex._httpStatusCode, ex._message, ex);
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
                throw new MinisterioRecomecoException(ex._httpStatusCode, ex._message, ex);
            }
        }

        public async Task<Celula> GetByIdAsync(Int64 id)
        {
            try
            {
                var celula = await _celulaRepository.GetByIdAsync(id) ?? await Task.FromResult<Celula>(null);
                return celula ?? throw new MinisterioRecomecoException(HttpStatusCode.NotFound, ELEMENTO_NAO_ENCONTRADO);
            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(ex._httpStatusCode, ex._message, ex);
            }
        }

        public async Task UpdateAsync(Celula item)
        {
            try
            {
                item.DataAlteracao = DateTime.Now;

                await _celulaRepository.UpdateAsync(item);
            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(ex._httpStatusCode, ex._message, ex);
            }
        }
    }
}
