using ApiMinisterioRecomeco.Models;

namespace ApiMinisterioRecomeco.Infrastructure
{
    public interface ICelulaRepository
    {
        Task<List<Celula>> GetAllAsync();
        Task<Celula> GetByIdAsync(Int64 id);
        Task CreateAsync(Celula celula);
        Task UpdateAsync(Celula celula);
        Task DeleteAsync(Celula celula);
    }
}
