using Lokata.DataAccess;
using Lokata.Domain;
using Lokata.Domain.Services;

namespace Lokata.DataService
{
    public class ScoreCardService : BaseDataService<ScoreCard>, IScoreCardService
    {
        public ScoreCardService(DatabaseContext context) : base(context)
        {
        }
    }
}
