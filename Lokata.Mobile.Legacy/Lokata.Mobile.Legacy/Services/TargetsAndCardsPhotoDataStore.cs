using Lokata.Mobile.Legacy.Services.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace Lokata.Mobile.Legacy.Services
{
    public class TargetsAndCardsPhotoDataStore : AListDataStore<TargetsAndCardsPhoto>
    {
        public TargetsAndCardsPhotoDataStore()
        {
            items = webapi.TargetsAndCardsPhotosAllAsync().GetAwaiter().GetResult().ToList();
        }

        public override TargetsAndCardsPhoto Find(TargetsAndCardsPhoto item)
        {
            return items.FirstOrDefault(arg => arg.Id == item.Id);
        }

        public override async Task<TargetsAndCardsPhoto> Find(int id)
        {
            return await webapi.TargetsAndCardsPhotosGETAsync(id);
        }

        public override async Task Refresh()
        {
            items = (await webapi.TargetsAndCardsPhotosAllAsync()).ToList();
        }

        public override async Task<bool> DeleteItemFromService(TargetsAndCardsPhoto item)
        {
            return await webapi.TargetsAndCardsPhotosDELETEAsync(item.Id);
        }

        public override async Task<bool> UpdateItemInService(TargetsAndCardsPhoto item)
        {
            return await webapi.TargetsAndCardsPhotosPUTAsync(item.Id, item);
        }

        public override async Task<TargetsAndCardsPhoto> AddItemToService(TargetsAndCardsPhoto item)
        {
            return await webapi.TargetsAndCardsPhotosPOSTAsync(item);
        }
    }
}
