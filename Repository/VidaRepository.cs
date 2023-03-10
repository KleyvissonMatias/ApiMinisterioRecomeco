using ApiMinisterioRecomeco.Models;

namespace ApiMinisterioRecomeco.Repository
{
    public abstract class VidaRepository : IRepository<Vida>
    {
        public abstract Task<List<Vida>> GetAllAsync();
        public abstract Task<Vida> GetByIdAsync(long id);
        public abstract Task CreateAsync(Vida vida);
        public abstract Task UpdateAsync(Vida vida);
        public abstract Task DeleteAsync(Vida vida);
    }
}
