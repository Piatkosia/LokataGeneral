using Lokata.DataAccess;
using Lokata.Domain;
using Lokata.Domain.Services;

using Microsoft.EntityFrameworkCore;

namespace Lokata.DataService
{
    public class PlaceService : BaseDataService<Place>, IPlaceService
    {
        public PlaceService(DatabaseContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Place>> GetAllWithDependencies()
        {
            return await Context.Places
                .Include(a => a.AddressNavigation)
                .ToListAsync();
        }

        public async Task<Place> GetWithDependencies(int id)
        {
            return await Context.Places
                .Include(a => a.AddressNavigation)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public IEnumerable<Place> GetAllWithDependenciesSync()
        {
            return Context.Places
                .Include(a => a.AddressNavigation)
                .ToList();
        }
    }
}
