namespace Lokata.Domain.Services
{
    public interface IAddressService : IDataService<Address>, ILookupable
    {
        Task<IEnumerable<Address>> GetAllWithDependencies();
    }
}
