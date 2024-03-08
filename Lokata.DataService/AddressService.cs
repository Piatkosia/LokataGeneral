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

        public List<LookupItem> GetLookup()
        {
            return Context.Addresses
             .Select(x => new LookupItem()
             {
                 Id = x.Id,
                 DisplayValue = $"{x.FullName} {x.Street} {x.Number} ; {x.PostalCode} {x.PostalPlace}"
             }).ToList();
        }

        public async Task<IEnumerable<Address>> GetAllWithDependencies()
        {
            return await Context.Addresses
                .Include(a => a.Places)
                .ToListAsync();
        }
    }
}