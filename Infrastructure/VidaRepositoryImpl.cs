using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Repository;

namespace ApiMinisterioRecomeco.Infrastructure
{
    public class VidaRepositoryImpl : IVidaRepository
    {
        private readonly MinisterioDbContext _dbContext;
        private readonly ILogger<Vida> _logger;

        private const string ERRO_INTERNO = "Ocorreu um erro Interno.";
        private const string ELEMENTO_NAO_ENCONTRADO = "Elemento não encontrado.";

        public VidaRepositoryImpl(MinisterioDbContext dbContext, ILogger<Vida> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Task Create(Vida vida)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Vida>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Vida> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Vida vida)
        {
            throw new NotImplementedException();
        }
    }
}
