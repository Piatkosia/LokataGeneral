using Lokata.DataAccess;
using Lokata.Domain;
using Lokata.Domain.Services;

namespace Lokata.DataService
{
    public class CompetitionService : BaseDataService<Competition>, ICompetitionService
    {
        public CompetitionService(DatabaseContext context) : base(context)
        {
        }

        public List<LookupItem> GetLookup()
        {
            return Context.Competitions
                .Select(x => new LookupItem()
                {
                    Id = x.Id,
                    DisplayValue = x.Name
                }).ToList();
        }
    }
}
