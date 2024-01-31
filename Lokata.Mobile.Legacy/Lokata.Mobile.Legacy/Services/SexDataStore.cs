using Lokata.Mobile.Legacy.Services.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace Lokata.Mobile.Legacy.Services
{
    public class SexDataStore : AListDataStore<Sex>
    {
        public SexDataStore()
        {
            items = webapi.SexesAllAsync().GetAwaiter().GetResult().ToList();
        }

        public override Sex Find(Sex item)
        {
            return items.FirstOrDefault(arg => arg.Id == item.Id);
        }

        public override async Task<Sex> Find(int id)
        {
            return await webapi.SexesGETAsync(id);
        }

        public override async Task Refresh()
        {
            items = (await webapi.SexesAllAsync()).ToList();
        }

        public override async Task<bool> DeleteItemFromService(Sex item)
        {
            return await webapi.SexesDELETEAsync(item.Id);
        }

        public override async Task<bool> UpdateItemInService(Sex item)
        {
            return await webapi.SexesPUTAsync(item.Id, item);
        }

        public override async Task<Sex> AddItemToService(Sex item)
        {
            return await webapi.SexesPOSTAsync(item);
        }
    }
}
