using Lokata.Mobile.Legacy.Helpers;
using Lokata.Mobile.Legacy.Services.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace Lokata.Mobile.Legacy.Services
{
    public class AddressDataStore : AListDataStore<Address>
    {
        public AddressDataStore() : base()
        {
            items = webapi.AddressAllAsync().GetAwaiter().GetResult().ToList();
        }

        public override Address Find(Address item)
        {
            return items.Where((arg) => arg.Id == item.Id).FirstOrDefault();
        }

        public override async Task<Address> Find(int id)
        {
            return await webapi.AddressGETAsync(id).HandleRequest();
        }

        public override async Task Refresh()
        {
            items = (await webapi.AddressAllAsync()).ToList();
        }

        public override Task<bool> DeleteItemFromService(Address item)
        {
            return webapi.AddressDELETEAsync(item.Id).HandleRequest();
        }

        public override Task<bool> UpdateItemInService(Address item)
        {
            return webapi.AddressPUTAsync(item.Id, item).HandleRequest();
        }

        public override Task<Address> AddItemToService(Address item)
        {
            return webapi.AddressPOSTAsync(item).HandleRequest();
        }
    }
}
