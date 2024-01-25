namespace Lokata.Domain.Services
{
    public interface ICompetitorService : IDataService<Competitor>
    {
        Task<IEnumerable<Competitor>> GetAllWithSex();
    }
}
