using ApiMinisterioRecomeco.Models;

namespace ApiMinisterioRecomeco.Repository
{
    public abstract class CelulaRepository
    {
        public abstract Task<List<Celula>> GetAllAsync();
        public abstract Task<Celula> GetByIdAsync(long id);
        public abstract Task CreateAsync(Celula celula);
        public abstract Task UpdateAsync(Celula celula);
        public abstract Task DeleteAsync(Celula celula);
    }
}
