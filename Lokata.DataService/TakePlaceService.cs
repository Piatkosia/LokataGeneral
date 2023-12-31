using Lokata.DataAccess;
using Lokata.Domain;
using Lokata.Domain.Services;

namespace Lokata.DataService
{
    public class TakePlaceService : BaseDataService<TakePlace>, ITakePlaceService
    {
        public TakePlaceService(DatabaseContext context) : base(context)
        {
        }
    }
}
