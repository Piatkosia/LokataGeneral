using Lokata.Domain;
using Refit;

namespace Lokata.Refit.Clients
{
    [Headers("Content-Type: application/json")]
    public interface IApproachClient
    {
        [Get("/api/Approach")]
        Task<IEnumerable<Approach>> Get();
        [Get("/api/Approach/{id}")]
        Task<Approach> Get(int id);
        [Post("/api/Approach")]
        Task Post(Approach address);
        [Put("/api/Approach/{id}")]
        Task Put(int id, Approach address);
        [Delete("/api/Approach/{id}")]
        Task Delete(int id);
    }
}
