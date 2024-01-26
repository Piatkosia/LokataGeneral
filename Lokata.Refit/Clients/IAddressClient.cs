using Lokata.Domain;
using Refit;

namespace Lokata.Refit.Clients
{
    [Headers("Content-Type: application/json")]
    public interface IAddressClient
    {
        [Get("/api/Address")]
        Task<IEnumerable<Address>> Get();
        [Get("/api/Address/{id}")]
        Task<Address> Get(int id);
        [Post("/api/Address")]
        Task Post(Address address);
        [Put("/api/Address/{id}")]
        Task Put(int id, Address address);
        [Delete("/api/Address/{id}")]
        Task Delete(int id);
    }
}
