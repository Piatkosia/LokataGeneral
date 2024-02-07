using Lokata.Mobile.Legacy.Helpers;
using Lokata.Mobile.Legacy.Services.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace Lokata.Mobile.Legacy.Services
{
    public class TakePlaceDataStore : AListDataStore<TakePlace>
    {
        public TakePlaceDataStore()
        {
            items = webapi.TakePlaceAllAsync().GetAwaiter().GetResult().ToList();
        }

        public override TakePlace Find(TakePlace item)
        {
            return items.FirstOrDefault(arg => arg.Id == item.Id);
        }

        public override async Task<TakePlace> Find(int id)
        {
            return await webapi.TakePlaceGETAsync(id);
        }

        public override async Task Refresh()
        {
            items = (await webapi.TakePlaceAllAsync()).ToList();
        }

        public override async Task<bool> DeleteItemFromService(TakePlace item)
        {
            return await webapi.TakePlaceDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<bool> UpdateItemInService(TakePlace item)
        {
            return await webapi.TakePlacePUTAsync(item.Id, item).HandleRequest();
        }

        public override async Task<TakePlace> AddItemToService(TakePlace item)
        {
            return await webapi.TakePlacePOSTAsync(item);
        }
    }
}
