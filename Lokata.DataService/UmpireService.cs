using Lokata.DataAccess;
using Lokata.Domain;
using Lokata.Domain.Services;

namespace Lokata.DataService
{
    public class UmpireService : BaseDataService<Umpire>, IUmpireService
    {
        public UmpireService(DatabaseContext context) : base(context)
        {
        }

        public List<LookupItem> GetLookup()
        {
            return Context.Umpires
                .Select(x => new LookupItem()
                {
                    Id = x.Id,
                    DisplayValue = x.FullName
                }).ToList();
        }
    }
}
