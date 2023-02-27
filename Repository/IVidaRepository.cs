using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Repository;

namespace ApiMinisterioRecomeco.Infrastructure
{
    public interface IVidaRepository
    {
        Task<List<Vida>> GetAllAsync();
        Task<Vida> GetByIdAsync(long id);
        Task CreateAsync(Vida vida);
        Task UpdateAsync(Vida vida);
        Task DeleteAsync(Vida vida);
    }
}
