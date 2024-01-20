using Lokata.DataAccess;
using Lokata.Domain;
using Lokata.Domain.Services;

namespace Lokata.DataService
{
    internal class UmpireService : BaseDataService<Umpire>, IUmpireService
    {
        public UmpireService(DatabaseContext context) : base(context)
        {
        }
    }
}
