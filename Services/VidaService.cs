using ApiMinisterioRecomeco.Exception;
using ApiMinisterioRecomeco.Infrastructure;
using ApiMinisterioRecomeco.Models;
using System.Net;

namespace ApiMinisterioRecomeco.Services
{
    public class VidaService : IService<Vida>
    {
        private readonly IVidaRepository _vidaRepository;
        private readonly ILogger<Vida> _logger;

        private const string ERRO_INTERNO = "Ocorreu um erro Interno.";
        private const string ELEMENTO_NAO_ENCONTRADO = "Elemento não encontrado.";

        public VidaService(IVidaRepository vidaRepository, ILogger<Vida> logger)
        {
            _vidaRepository = vidaRepository;
            _logger = logger;
        }

        public async Task CreateAsync(Vida item)
        {
            try
            {
                await _vidaRepository.CreateAsync(item);
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
                var vida = await GetByIdAsync(id) ?? throw new MinisterioRecomecoException(HttpStatusCode.NotFound, ELEMENTO_NAO_ENCONTRADO);
                await _vidaRepository.DeleteAsync(vida);
            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(HttpStatusCode.InternalServerError, ERRO_INTERNO, ex);
            }
        }

        public async Task<List<Vida>> GetAllAsync()
        {
            try
            {
                return await _vidaRepository.GetAllAsync();
            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(HttpStatusCode.InternalServerError, ERRO_INTERNO, ex);
            }
        }

        public async Task<Vida> GetByIdAsync(long id)
        {
            try
            {
                return await _vidaRepository.GetByIdAsync(id) ?? throw new MinisterioRecomecoException(HttpStatusCode.NotFound, ELEMENTO_NAO_ENCONTRADO);
            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(HttpStatusCode.InternalServerError, ERRO_INTERNO, ex);
            }
        }

        public async Task UpdateAsync(Vida item)
        {
            try
            {
                await _vidaRepository.UpdateAsync(item);
            }
            catch (MinisterioRecomecoException ex)
            {
                throw new MinisterioRecomecoException(HttpStatusCode.InternalServerError, ERRO_INTERNO, ex);
            }
        }
    }
}
