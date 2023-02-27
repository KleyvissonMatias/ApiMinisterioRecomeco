using ApiMinisterioRecomeco.Exception;
using ApiMinisterioRecomeco.Infrastructure;
using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Repository;
using System.Net;

namespace ApiMinisterioRecomeco.Services
{
    public class RelatorioService : IService<Relatorio>
    {
        private readonly IRelatorioRepository _relatorioRepository;
        private readonly ILogger<Relatorio> _logger;

        private const string ERRO_INTERNO = "Ocorreu um erro Interno.";
        private const string ELEMENTO_NAO_ENCONTRADO = "Elemento não encontrado.";

        public RelatorioService(IRelatorioRepository relatorioRepository, ILogger<Relatorio> logger)
        {
            _relatorioRepository = relatorioRepository;
            _logger = logger;
        }

        public async Task CreateAsync(Relatorio item)
        {
            try
            {
                await _relatorioRepository.CreateAsync(item);
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
                var relatorio = await GetByIdAsync(id) ?? throw new MinisterioRecomecoException(HttpStatusCode.NotFound, ELEMENTO_NAO_ENCONTRADO);
                await _relatorioRepository.DeleteAsync(relatorio);
            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(HttpStatusCode.InternalServerError, ERRO_INTERNO, ex);
            }
        }

        public async Task<List<Relatorio>> GetAllAsync()
        {
            try
            {
                return await _relatorioRepository.GetAllAsync();
            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(HttpStatusCode.InternalServerError, ERRO_INTERNO, ex);
            }
        }

        public async Task<Relatorio> GetByIdAsync(long id)
        {
            try
            {
                return await _relatorioRepository.GetByIdAsync(id) ?? throw new MinisterioRecomecoException(HttpStatusCode.NotFound, ELEMENTO_NAO_ENCONTRADO);
            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(HttpStatusCode.InternalServerError, ERRO_INTERNO, ex);
            }
        }

        public async Task UpdateAsync(Relatorio item)
        {
            try
            {
                await _relatorioRepository.UpdateAsync(item);
            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(HttpStatusCode.InternalServerError, ERRO_INTERNO, ex);
            }
        }
    }
}
