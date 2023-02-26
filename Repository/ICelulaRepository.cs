using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Repository;

namespace ApiMinisterioRecomeco.Infrastructure
{
    public interface ICelulaRepository
    {
        Task<List<Celula>> GetAll();
        Task<Celula> GetById(long id);
        Task Create(Celula item);
        Task<Celula> Update(Celula item);
        Task Delete(long id);
    }
}
