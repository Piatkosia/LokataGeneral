using Lokata.Mobile.Legacy.Services.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace Lokata.Mobile.Legacy.Services
{
    public class TakePlaceDataStore : AListDataStore<TakePlace>
    {
        public TakePlaceDataStore()
        {
            items = webapi.TakePlacesAllAsync().GetAwaiter().GetResult().ToList();
        }

        public override TakePlace Find(TakePlace item)
        {
            return items.FirstOrDefault(arg => arg.Id == item.Id);
        }

        public override async Task<TakePlace> Find(int id)
        {
            return await webapi.TakePlacesGETAsync(id);
        }

        public override async Task Refresh()
        {
            items = (await webapi.TakePlacesAllAsync()).ToList();
        }

        public override async Task<bool> DeleteItemFromService(TakePlace item)
        {
            return await webapi.TakePlacesDELETEAsync(item.Id);
        }

        public override async Task<bool> UpdateItemInService(TakePlace item)
        {
            return await webapi.TakePlacesPUTAsync(item.Id, item);
        }

        public override async Task<TakePlace> AddItemToService(TakePlace item)
        {
            return await webapi.TakePlacesPOSTAsync(item);
        }
    }
}
