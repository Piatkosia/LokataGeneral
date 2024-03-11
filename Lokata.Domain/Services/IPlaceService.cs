namespace Lokata.Domain.Services
{
    public interface IPlaceService : IDataService<Place>, ILookupable
    {
        Task<IEnumerable<Place>> GetAllWithDependencies();
        Task<Place> GetWithDependencies(int id);
        IEnumerable<Place> GetAllWithDependenciesSync();
    }
}
