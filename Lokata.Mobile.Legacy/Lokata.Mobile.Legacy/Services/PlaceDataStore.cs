using Lokata.Mobile.Legacy.Helpers;
using Lokata.Mobile.Legacy.Services.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace Lokata.Mobile.Legacy.Services
{
    public class PlaceDataStore : AListDataStore<Place>
    {
        public PlaceDataStore()
        {
            items = webapi.PlaceAllAsync().GetAwaiter().GetResult().ToList();
        }
        public override Place Find(Place item)
        {
            return items.FirstOrDefault(arg => arg.Id == item.Id);
        }

        public override async Task<Place> Find(int id)
        {
            return await webapi.PlaceGETAsync(id);
        }

        public override async Task Refresh()
        {
            items = (await webapi.PlaceAllAsync()).ToList();
        }

        public override async Task<bool> DeleteItemFromService(Place item)
        {
            return await webapi.PlaceDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<bool> UpdateItemInService(Place item)
        {
            return await webapi.PlacePUTAsync(item.Id, item).HandleRequest();
        }

        public override async Task<Place> AddItemToService(Place item)
        {
            return await webapi.PlacePOSTAsync(item);
        }
    }
}
