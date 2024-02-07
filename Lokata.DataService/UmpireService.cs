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
    }
}
