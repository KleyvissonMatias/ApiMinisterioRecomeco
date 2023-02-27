using ApiMinisterioRecomeco.Models;

namespace ApiMinisterioRecomeco.Repository
{
    public interface IRelatorioRepository
    {
        Task<List<Relatorio>> GetAllAsync();
        Task<Relatorio> GetByIdAsync(long id);
        Task CreateAsync(Relatorio relatorio);
        Task UpdateAsync(Relatorio relatorio);
        Task DeleteAsync(Relatorio relatorio);
    }
}
