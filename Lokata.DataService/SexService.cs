using Lokata.DataAccess;
using Lokata.Domain;
using Lokata.Domain.Services;

namespace Lokata.DataService
{
    public class SexService : BaseDataService<Sex>, ISexService
    {
        public SexService(DatabaseContext context) : base(context)
        {
        }
    }
}
