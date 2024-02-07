using Lokata.Mobile.Legacy.Helpers;
using Lokata.Mobile.Legacy.Services.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace Lokata.Mobile.Legacy.Services
{
    public class TargetsAndCardsPhotoDataStore : AListDataStore<TargetsAndCardsPhoto>
    {
        public TargetsAndCardsPhotoDataStore()
        {
            items = webapi.TargetsAndCardsPhotoAllAsync().GetAwaiter().GetResult().ToList();
        }

        public override TargetsAndCardsPhoto Find(TargetsAndCardsPhoto item)
        {
            return items.FirstOrDefault(arg => arg.Id == item.Id);
        }

        public override async Task<TargetsAndCardsPhoto> Find(int id)
        {
            return await webapi.TargetsAndCardsPhotoGETAsync(id);
        }

        public override async Task Refresh()
        {
            items = (await webapi.TargetsAndCardsPhotoAllAsync()).ToList();
        }

        public override async Task<bool> DeleteItemFromService(TargetsAndCardsPhoto item)
        {
            return await webapi.TargetsAndCardsPhotoDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<bool> UpdateItemInService(TargetsAndCardsPhoto item)
        {
            return await webapi.TargetsAndCardsPhotoPUTAsync(item.Id, item).HandleRequest();
        }

        public override async Task<TargetsAndCardsPhoto> AddItemToService(TargetsAndCardsPhoto item)
        {
            return await webapi.TargetsAndCardsPhotoPOSTAsync(item);
        }
    }
}
