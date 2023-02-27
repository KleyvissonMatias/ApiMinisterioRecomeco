using ApiMinisterioRecomeco.Configuration;
using ApiMinisterioRecomeco.Models;

namespace ApiMinisterioRecomeco.Infrastructure
{
    public class VidaRepositoryImpl : IVidaRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<Vida> _logger;

        private const string ERRO_INTERNO = "Ocorreu um erro Interno.";
        private const string ELEMENTO_NAO_ENCONTRADO = "Elemento não encontrado.";

        public VidaRepositoryImpl(AppDbContext dbContext, ILogger<Vida> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Task CreateAsync(Vida vida)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Vida>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Vida> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Vida vida)
        {
            throw new NotImplementedException();
        }
    }
}
