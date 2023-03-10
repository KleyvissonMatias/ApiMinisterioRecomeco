using ApiMinisterioRecomeco.Exception;
using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Repository;
using System.Net;
using static ApiMinisterioRecomeco.Constants.Errors;

namespace ApiMinisterioRecomeco.Services
{
    public class CelulaService : IService<Celula>
    {
        private readonly CelulaRepository _celulaRepository;
        private readonly ILogger<Celula> _logger;

        private const string LOG_SERVICE = "CelulaService:";

        public CelulaService(CelulaRepository celulaRepository, ILogger<Celula> logger)
        {
            _celulaRepository = celulaRepository;
            _logger = logger;
        }

        public async Task CreateAsync(Celula item)
        {
            try
            {
                _logger.LogInformation(LOG_SERVICE + " [Criando célula] - [{}]", item);
                await _celulaRepository.CreateAsync(item);
            }
            catch (MinisterioRecomecoException ex)
            {
                _logger.LogError(ex, LOG_SERVICE + " [{}]", ex._message);
                throw new MinisterioRecomecoException(ex._httpStatusCode, ex._message, ex);
            }
        }

        public async Task DeleteAsync(Int64 id)
        {
            try
            {
                _logger.LogInformation(LOG_SERVICE + " [Deletando célula]");
                var celula = await GetByIdAsync(id) ?? throw new MinisterioRecomecoException(HttpStatusCode.NotFound, ELEMENTO_NAO_ENCONTRADO);
                await _celulaRepository.DeleteAsync(celula);
            }
            catch (MinisterioRecomecoException ex)
            {
                _logger.LogError(ex, LOG_SERVICE + " [{}]", ex._message);
                throw new MinisterioRecomecoException(ex._httpStatusCode, ex._message, ex);
            }
        }

        public async Task<List<Celula>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation(LOG_SERVICE + " [Listando células]");
                return await _celulaRepository.GetAllAsync();
            }
            catch (MinisterioRecomecoException ex)
            {
                _logger.LogError(ex, LOG_SERVICE + " [{}]", ex._message);
                throw new MinisterioRecomecoException(ex._httpStatusCode, ex._message, ex);
            }
        }

        public async Task<Celula> GetByIdAsync(Int64 id)
        {
            try
            {
                _logger.LogInformation(LOG_SERVICE + " [Obtendo célula por ID]");
                return await _celulaRepository.GetByIdAsync(id) ?? throw new MinisterioRecomecoException(HttpStatusCode.NotFound, ELEMENTO_NAO_ENCONTRADO);
            }
            catch (MinisterioRecomecoException ex)
            {
                _logger.LogError(ex, LOG_SERVICE + " [{}]", ex._message);
                throw new MinisterioRecomecoException(ex._httpStatusCode, ex._message, ex);
            }
        }

        public async Task UpdateAsync(Celula item)
        {
            try
            {
                _logger.LogInformation(LOG_SERVICE + " [Atualizando célula] - [{}]", item);

                item.DataAlteracao = DateTime.Now;

                await _celulaRepository.UpdateAsync(item);
            }
            catch (MinisterioRecomecoException ex)
            {
                _logger.LogError(ex, LOG_SERVICE + " [{}]", ex._message);
                throw new MinisterioRecomecoException(ex._httpStatusCode, ex._message, ex);
            }
        }
    }
}
