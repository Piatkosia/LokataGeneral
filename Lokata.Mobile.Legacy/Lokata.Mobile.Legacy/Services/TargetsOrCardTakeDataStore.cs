using Lokata.Mobile.Legacy.Helpers;
using Lokata.Mobile.Legacy.Services.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace Lokata.Mobile.Legacy.Services
{
    public class TargetsOrCardTakeDataStore : AListDataStore<TargetsOrCardTake>
    {
        public TargetsOrCardTakeDataStore()
        {
            items = webapi.TargetsOrCardTakeAllAsync().GetAwaiter().GetResult().ToList();
        }

        public override TargetsOrCardTake Find(TargetsOrCardTake item)
        {
            return items.FirstOrDefault(arg => arg.Id == item.Id);
        }

        public override async Task<TargetsOrCardTake> Find(int id)
        {
            return await webapi.TargetsOrCardTakeGETAsync(id);
        }

        public override async Task Refresh()
        {
            items = (await webapi.TargetsOrCardTakeAllAsync()).ToList();
        }

        public override async Task<bool> DeleteItemFromService(TargetsOrCardTake item)
        {
            return await webapi.TargetsOrCardTakeDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<bool> UpdateItemInService(TargetsOrCardTake item)
        {
            return await webapi.TargetsOrCardTakePUTAsync(item.Id, item).HandleRequest();
        }

        public override async Task<TargetsOrCardTake> AddItemToService(TargetsOrCardTake item)
        {
            return await webapi.TargetsOrCardTakePOSTAsync(item);
        }
    }
}
