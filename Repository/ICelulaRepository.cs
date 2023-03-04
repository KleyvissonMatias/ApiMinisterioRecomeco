using ApiMinisterioRecomeco.Models;

namespace ApiMinisterioRecomeco.Repository
{
    public interface ICelulaRepository
    {
        Task<List<Celula>> GetAllAsync();
        Task<Celula> GetByIdAsync(long id);
        Task CreateAsync(Celula celula);
        Task UpdateAsync(Celula celula);
        Task DeleteAsync(Celula celula);
    }
}
