using Lokata.DataAccess;
using Lokata.Domain;
using Lokata.Domain.Services;

namespace Lokata.DataService
{
    public class ApproachService : BaseDataService<Approach>, IApproachService
    {
        public ApproachService(DatabaseContext context) : base(context)
        {
        }
    }
}
