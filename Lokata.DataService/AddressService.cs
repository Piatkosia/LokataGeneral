using Lokata.DataAccess;
using Lokata.Domain;
using Lokata.Domain.Services;

using Microsoft.EntityFrameworkCore;

namespace Lokata.DataService
{
    public class AddressService : BaseDataService<Address>, IAddressService
    {

        public AddressService(DatabaseContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Address>> GetAllWithDependencies()
        {
            return await Context.Addresses
                .Include(a => a.Places)
                .ToListAsync();
        }
    }
}