namespace Lokata.Domain.Services
{
    public interface IPlaceService : IDataService<Place>
    {
        Task<IEnumerable<Place>> GetAllWithDependencies();
    }
}
