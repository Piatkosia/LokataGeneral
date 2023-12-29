namespace Lokata.Domain.Services
{
    public interface IAddressService : IDataService<Address>
    {
        Task<IEnumerable<Address>> GetAllWithDependencies();
    }
}
