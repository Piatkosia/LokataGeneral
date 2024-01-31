using Lokata.Mobile.Legacy.Services.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace Lokata.Mobile.Legacy.Services
{
    public class TargetsOrCardTakeDataStore : AListDataStore<TargetsOrCardTake>
    {
        public TargetsOrCardTakeDataStore()
        {
            items = webapi.TargetsOrCardTakesAllAsync().GetAwaiter().GetResult().ToList();
        }

        public override TargetsOrCardTake Find(TargetsOrCardTake item)
        {
            return items.FirstOrDefault(arg => arg.Id == item.Id);
        }

        public override async Task<TargetsOrCardTake> Find(int id)
        {
            return await webapi.TargetsOrCardTakesGETAsync(id);
        }

        public override async Task Refresh()
        {
            items = (await webapi.TargetsOrCardTakesAllAsync()).ToList();
        }

        public override async Task<bool> DeleteItemFromService(TargetsOrCardTake item)
        {
            return await webapi.TargetsOrCardTakesDELETEAsync(item.Id);
        }

        public override async Task<bool> UpdateItemInService(TargetsOrCardTake item)
        {
            return await webapi.TargetsOrCardTakesPUTAsync(item.Id, item);
        }

        public override async Task<TargetsOrCardTake> AddItemToService(TargetsOrCardTake item)
        {
            return await webapi.TargetsOrCardTakesPOSTAsync(item);
        }
    }
}
