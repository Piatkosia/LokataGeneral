using Lokata.DataAccess;
using Lokata.Domain;
using Lokata.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Lokata.DataService
{
    public class CompetitorService : BaseDataService<Competitor>, ICompetitorService
    {
        public CompetitorService(DatabaseContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Competitor>> GetAllWithSex()
        {
            return await Context.Competitors
                .Include(a => a.Sex)
                .ToListAsync();
        }

        public async Task<Competitor> GetByIdWithSex(int id)
        {
            return await Context.Competitors
                .Include(a => a.Sex)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
