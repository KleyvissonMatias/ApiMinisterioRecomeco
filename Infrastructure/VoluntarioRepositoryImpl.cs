using ApiMinisterioRecomeco.Configuration;
using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Repository;
using Microsoft.EntityFrameworkCore;

namespace ApiMinisterioRecomeco.Infrastructure
{
    public class VoluntarioRepositoryImpl : VoluntarioRepository
    {
        private readonly AppDbContext _dbContext;

        public VoluntarioRepositoryImpl(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task CreateAsync(Voluntario voluntario)
        {
            _dbContext.Voluntarios.Add(voluntario);
            await _dbContext.SaveChangesAsync();
        }

        public override async Task DeleteAsync(Voluntario voluntario)
        {
            _dbContext.Voluntarios.Remove(voluntario);
            await _dbContext.SaveChangesAsync();
        }

        public override async Task<List<Voluntario>> GetAllAsync()
        {
            return await _dbContext.Voluntarios.ToListAsync();
        }

        public override async Task<Voluntario> GetByIdAsync(Int64 id)
        {
            return await _dbContext.Voluntarios.FirstOrDefaultAsync(v => v.Id == id) ?? await Task.FromResult<Voluntario>(null);
        }

        public override async Task UpdateAsync(Voluntario voluntario)
        {
            _dbContext.Voluntarios.Update(voluntario);
            await _dbContext.SaveChangesAsync();
        }
    }
}
