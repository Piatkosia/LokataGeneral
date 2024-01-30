using Lokata.Mobile.Legacy.Helpers;
using Lokata.Mobile.Legacy.Services.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace Lokata.Mobile.Legacy.Services
{
    public class ApproachDataStore : AListDataStore<Approach>
    {
        public ApproachDataStore()
        {
            items = webapi.ApproachAllAsync().GetAwaiter().GetResult().ToList();
        }

        public override Approach Find(Approach item)
        {
            return items.FirstOrDefault(arg => arg.Id == item.Id);
        }

        public override async Task<Approach> Find(int id)
        {
            return await webapi.ApproachGETAsync(id).HandleRequest();
        }

        public override async Task Refresh()
        {
            items = (await webapi.ApproachAllAsync()).ToList();
        }

        public override async Task<bool> DeleteItemFromService(Approach item)
        {
            return await webapi.ApproachDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<bool> UpdateItemInService(Approach item)
        {
            return await webapi.ApproachPUTAsync(item.Id, item).HandleRequest();
        }

        public override async Task<Approach> AddItemToService(Approach item)
        {
            return await webapi.ApproachPOSTAsync(item).HandleRequest();
        }
    }
}
