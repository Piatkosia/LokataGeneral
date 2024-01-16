namespace Lokata.Domain.Services
{
    public interface IDataService<T> where T : EntityBase
    {
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> GetAll();
        Task<T> GetById(int id);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task<bool> Exists(int id);
    }
}
