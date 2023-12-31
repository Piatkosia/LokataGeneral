using Lokata.DataAccess;
using Lokata.Domain;
using Lokata.Domain.Services;

namespace Lokata.DataService
{
    public class TargetsAndCardsPhotoService : BaseDataService<TargetsAndCardsPhoto>, ITargetsAndCardsPhotoService
    {
        public TargetsAndCardsPhotoService(DatabaseContext context) : base(context)
        {
        }
    }
}
