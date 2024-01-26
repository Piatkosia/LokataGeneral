using Lokata.Domain;
using Refit;

namespace Lokata.Refit.Clients
{
    [Headers("Content-Type: application/json")]
    public interface IDocumentClient
    {
        [Get("/api/Document")]
        Task<IEnumerable<Document>> Get();
        [Get("/api/Document/{id}")]
        Task<Document> Get(int id);
        [Post("/api/Document")]
        Task Post(Document address);
        [Put("/api/Document/{id}")]
        Task Put(int id, Document address);
        [Delete("/api/Document/{id}")]
        Task Delete(int id);
    }
}
