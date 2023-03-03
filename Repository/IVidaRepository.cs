using ApiMinisterioRecomeco.Models;

namespace ApiMinisterioRecomeco.Infrastructure
{
    public interface IVidaRepository
    {
        Task<List<Vida>> GetAllAsync();
        Task<Vida> GetByIdAsync(Int64 id);
        Task CreateAsync(Vida vida);
        Task UpdateAsync(Vida vida);
        Task DeleteAsync(Vida vida);
    }
}
