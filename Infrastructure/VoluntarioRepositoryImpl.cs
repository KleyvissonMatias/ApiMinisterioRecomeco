using ApiMinisterioRecomeco.Configuration;
using ApiMinisterioRecomeco.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMinisterioRecomeco.Infrastructure
{
    public class VoluntarioRepositoryImpl : IVoluntarioRepository
    {
        private readonly AppDbContext _dbContext;

        public VoluntarioRepositoryImpl(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Voluntario voluntario)
        {
            _dbContext.Voluntarios.Add(voluntario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Voluntario voluntario)
        {
            _dbContext.Voluntarios.Remove(voluntario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Voluntario>> GetAllAsync()
        {
            return await _dbContext.Voluntarios.ToListAsync();
        }

        public async Task<Voluntario> GetByIdAsync(Int64 id)
        {
            return await _dbContext.Voluntarios.FirstOrDefaultAsync(v => v.Id == id) ?? await Task.FromResult<Voluntario>(null);
        }

        public async Task UpdateAsync(Voluntario voluntario)
        {
            _dbContext.Voluntarios.Update(voluntario);
            await _dbContext.SaveChangesAsync();
        }
    }
}
