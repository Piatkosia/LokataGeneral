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
    }
}
