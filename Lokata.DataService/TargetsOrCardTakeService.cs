using Lokata.DataAccess;
using Lokata.Domain;
using Lokata.Domain.Services;

namespace Lokata.DataService
{
    public class TargetsOrCardTakeService : BaseDataService<TargetsOrCardTake>, ITargetsOrCardTakeService
    {
        public TargetsOrCardTakeService(DatabaseContext context) : base(context)
        {
        }
    }
}
