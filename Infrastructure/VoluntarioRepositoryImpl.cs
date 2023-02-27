using ApiMinisterioRecomeco.Configuration;
using ApiMinisterioRecomeco.Models;

namespace ApiMinisterioRecomeco.Infrastructure
{
    public class VoluntarioRepositoryImpl : IVoluntarioRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<Voluntario> _logger;

        private const string ERRO_INTERNO = "Ocorreu um erro Interno.";
        private const string ELEMENTO_NAO_ENCONTRADO = "Elemento não encontrado.";

        public VoluntarioRepositoryImpl(AppDbContext dbContext, ILogger<Voluntario> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Task CreateAsync(Voluntario item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Voluntario>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Voluntario> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Voluntario item)
        {
            throw new NotImplementedException();
        }
    }
}
