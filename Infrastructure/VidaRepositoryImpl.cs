using ApiMinisterioRecomeco.Configuration;
using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Repository;
using Microsoft.EntityFrameworkCore;

namespace ApiMinisterioRecomeco.Infrastructure
{
    public class VidaRepositoryImpl : VidaRepository
    {
        private readonly AppDbContext _dbContext;

        public VidaRepositoryImpl(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task CreateAsync(Vida vida)
        {
            _dbContext.Vidas.Add(vida);
            await _dbContext.SaveChangesAsync();
        }

        public override async Task DeleteAsync(Vida vida)
        {
            _dbContext.Vidas.Remove(vida);
            await _dbContext.SaveChangesAsync();
        }

        public override async Task<List<Vida>> GetAllAsync()
        {
            return await _dbContext.Vidas.Include(e => e.Endereco).ToListAsync();
        }

        public override async Task<Vida> GetByIdAsync(Int64 id)
        {
            return await _dbContext.Vidas.Include(e => e.Endereco).FirstOrDefaultAsync(v => v.Id == id) ?? await Task.FromResult<Vida>(null);
        }

        public override async Task UpdateAsync(Vida vida)
        {
            _dbContext.Vidas.Update(vida);
            await _dbContext.SaveChangesAsync();
        }
    }
}
