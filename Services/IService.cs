using ApiMinisterioRecomeco.Models;

namespace ApiMinisterioRecomeco.Services
{
    public interface IService<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(long id);
        Task Create(T item);
        Task Update(T item);
        Task Delete(long id);
    }
}
