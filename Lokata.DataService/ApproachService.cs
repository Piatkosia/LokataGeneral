using Lokata.DataAccess;
using Lokata.Domain;
using Lokata.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Lokata.DataService
{
    public class ApproachService : BaseDataService<Approach>, IApproachService
    {
        public ApproachService(DatabaseContext context) : base(context)
        {
        }

        public async Task<Approach> GetAllWithDependencies(int id)
        {
            return await Context.Approaches
                .Include(x => x.Competition)
                .Include(x => x.Competitions)
                .Include(a => a.ScoreCards)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
