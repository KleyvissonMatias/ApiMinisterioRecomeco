using ApiMinisterioRecomeco.Models;

namespace ApiMinisterioRecomeco.Repository
{
    public abstract class CelulaRepository : IRepository<Celula>
    {
        public abstract Task CreateAsync(Celula celula);
        public abstract Task DeleteAsync(Celula celula);
        public abstract Task<List<Celula>> GetAllAsync();
        public abstract Task<Celula> GetByIdAsync(Int64 id);
        public abstract Task UpdateAsync(Celula celula);
    }
}
