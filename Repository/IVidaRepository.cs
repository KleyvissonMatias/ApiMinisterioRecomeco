using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Repository;

namespace ApiMinisterioRecomeco.Infrastructure
{
    public interface IVidaRepository
    {
        Task<List<Vida>> GetAll();
        Task<Vida> GetById(long id);
        Task Create(Vida vida);
        Task<Vida> Update(Vida vida);
        Task Delete(long id);
    }
}
