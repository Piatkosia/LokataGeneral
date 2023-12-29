using Lokata.DataAccess;
using Lokata.Domain;
using Lokata.Domain.Services;

namespace Lokata.DataService
{
    public class CompetitorService : BaseDataService<Competitor>, ICompetitorService
    {
        public CompetitorService(DatabaseContext context) : base(context)
        {
        }
    }
}
