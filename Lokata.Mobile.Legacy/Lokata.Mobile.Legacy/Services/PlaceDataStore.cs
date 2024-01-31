using Lokata.Mobile.Legacy.Services.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace Lokata.Mobile.Legacy.Services
{
    public class PlaceDataStore : AListDataStore<Place>
    {
        public PlaceDataStore()
        {
            items = webapi.PlacesAllAsync().GetAwaiter().GetResult().ToList();
        }
        public override Place Find(Place item)
        {
            return items.FirstOrDefault(arg => arg.Id == item.Id);
        }

        public override async Task<Place> Find(int id)
        {
            return await webapi.PlacesGETAsync(id);
        }

        public override async Task Refresh()
        {
            items = (await webapi.PlacesAllAsync()).ToList();
        }

        public override async Task<bool> DeleteItemFromService(Place item)
        {
            return await webapi.PlacesDELETEAsync(item.Id);
        }

        public override async Task<bool> UpdateItemInService(Place item)
        {
            return await webapi.PlacesPUTAsync(item.Id, item);
        }

        public override async Task<Place> AddItemToService(Place item)
        {
            return await webapi.PlacesPOSTAsync(item);
        }
    }
}
