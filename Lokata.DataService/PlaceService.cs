using Lokata.DataAccess;
using Lokata.Domain;
using Lokata.Domain.Services;

namespace Lokata.DataService
{
    public class PlaceService : BaseDataService<Place>, IPlaceService
    {
        public PlaceService(DatabaseContext context) : base(context)
        {
        }
    }
}
