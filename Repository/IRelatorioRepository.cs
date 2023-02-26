using ApiMinisterioRecomeco.Models;

namespace ApiMinisterioRecomeco.Repository
{
    public interface IRelatorioRepository
    {
        Task<List<Relatorio>> GetAll();
        Task<Relatorio> GetById(long id);
        Task Create(Relatorio item);
        Task Update(Relatorio item);
        Task Delete(long id);
    }
}
