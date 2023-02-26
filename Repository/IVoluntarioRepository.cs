using ApiMinisterioRecomeco.Models;
using ApiMinisterioRecomeco.Repository;

namespace ApiMinisterioRecomeco.Infrastructure
{
    public interface IVoluntarioRepository
    {
        Task<List<Voluntario>> GetAll();
        Voluntario GetById(long id);
        Task Create(Voluntario item);
        Task<Voluntario> Update(Voluntario item);
        Task Delete(long id);
    }
}
