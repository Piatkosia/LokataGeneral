namespace Lokata.Domain.Services
{
    public interface IApproachService : IDataService<Approach>
    {
        public Task<Approach> GetAllWithDependencies(int id);
    }
}
