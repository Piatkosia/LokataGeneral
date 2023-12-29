using Lokata.DataAccess;
using Lokata.Domain;
using Lokata.Domain.Services;

namespace Lokata.DataService
{
    public class CompetitionsService : BaseDataService<Competitions>, ICompetitionsService
    {
        public CompetitionsService(DatabaseContext context) : base(context)
        {
        }
    }
}
