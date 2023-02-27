using ApiMinisterioRecomeco.Models;

namespace ApiMinisterioRecomeco.Repository
{
    public interface IRelatorioRepository
    {
        Task<List<Relatorio>> GetAllAsync();
        Task<Relatorio> GetByIdAsync(long id);
        Task CreateAsync(Relatorio item);
        Task UpdateAsync(Relatorio item);
        Task DeleteAsync(long id);
    }
}
