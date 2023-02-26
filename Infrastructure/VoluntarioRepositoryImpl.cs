using ApiMinisterioRecomeco.Configuration;
using ApiMinisterioRecomeco.Models;

namespace ApiMinisterioRecomeco.Infrastructure
{
    public class VoluntarioRepositoryImpl : IVoluntarioRepository
    {
        private readonly MinisterioDbContext _dbContext;
        private readonly ILogger<Voluntario> _logger;

        private const string ERRO_INTERNO = "Ocorreu um erro Interno.";
        private const string ELEMENTO_NAO_ENCONTRADO = "Elemento não encontrado.";

        public VoluntarioRepositoryImpl(MinisterioDbContext dbContext, ILogger<Voluntario> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Task Create(Voluntario item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Voluntario>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Voluntario> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Voluntario item)
        {
            throw new NotImplementedException();
        }
    }
}
