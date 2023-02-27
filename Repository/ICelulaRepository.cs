using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Repository;

namespace ApiMinisterioRecomeco.Infrastructure
{
    public interface ICelulaRepository
    {
        Task<List<Celula>> GetAllAsync();
        Task<Celula> GetByIdAsync(long id);
        Task CreateAsync(Celula item);
        Task UpdateAsync(Celula item);
        Task DeleteAsync(Celula item);
    }
}
