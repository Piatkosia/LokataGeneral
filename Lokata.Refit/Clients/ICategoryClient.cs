using Lokata.Domain;
using Refit;

namespace Lokata.Refit.Clients
{
    [Headers("Content-Type: application/json")]
    public interface ICategoryClient
    {
        [Get("/api/Category")]
        Task<IEnumerable<Category>> Get();
        [Get("/api/Category/{id}")]
        Task<Category> Get(int id);
        [Post("/api/Category")]
        Task Post(Category address);
        [Put("/api/Category/{id}")]
        Task Put(int id, Category address);
        [Delete("/api/Category/{id}")]
        Task Delete(int id);
    }
}
