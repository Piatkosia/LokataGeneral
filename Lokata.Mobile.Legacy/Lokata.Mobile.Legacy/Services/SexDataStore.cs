using Lokata.Mobile.Legacy.Helpers;
using Lokata.Mobile.Legacy.Services.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace Lokata.Mobile.Legacy.Services
{
    public class SexDataStore : AListDataStore<Sex>
    {
        public SexDataStore()
        {
            items = webapi.SexAllAsync().GetAwaiter().GetResult().ToList();
        }

        public override Sex Find(Sex item)
        {
            return items.FirstOrDefault(arg => arg.Id == item.Id);
        }

        public override async Task<Sex> Find(int id)
        {
            return await webapi.SexGETAsync(id);
        }

        public override async Task Refresh()
        {
            items = (await webapi.SexAllAsync()).ToList();
        }

        public override async Task<bool> DeleteItemFromService(Sex item)
        {
            return await webapi.SexDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<bool> UpdateItemInService(Sex item)
        {
            return await webapi.SexPUTAsync(item.Id, item).HandleRequest();
        }

        public override async Task<Sex> AddItemToService(Sex item)
        {
            return await webapi.SexPOSTAsync(item);
        }
    }
}
