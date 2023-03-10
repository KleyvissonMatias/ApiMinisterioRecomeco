using ApiMinisterioRecomeco.Models;

namespace ApiMinisterioRecomeco.Repository
{
    public abstract class CelulaRepository : IRepository<Celula>
    {
        public abstract Task CreateAsync(Celula t);
        public abstract Task DeleteAsync(Celula t);
        public abstract Task<List<Celula>> GetAllAsync();
        public abstract Task<Celula> GetByIdAsync(long id);
        public abstract Task UpdateAsync(Celula t);
    }
}
