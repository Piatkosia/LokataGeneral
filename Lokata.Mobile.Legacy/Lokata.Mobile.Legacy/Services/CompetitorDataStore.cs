using Lokata.Mobile.Legacy.Services.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace Lokata.Mobile.Legacy.Services
{
    public class CompetitorDataStore : AListDataStore<Competitor>
    {
        public CompetitorDataStore()
        {
            items = webapi.CompetitorAllAsync().GetAwaiter().GetResult().ToList();
        }

        public override Competitor Find(Competitor item)
        {
            return items.FirstOrDefault(arg => arg.Id == item.Id);
        }

        public override async Task<Competitor> Find(int id)
        {
            return await webapi.CompetitorGETAsync(id).HandleRequest();
        }

        public override async Task Refresh()
        {
            items = (await webapi.CompetitorAllAsync()).ToList();
        }

        public override async Task<bool> DeleteItemFromService(Competitor item)
        {
            return await webapi.CompetitorDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<bool> UpdateItemInService(Competitor item)
        {
            return await webapi.CompetitorPUTAsync(item.Id, item).HandleRequest();
        }

        public override async Task<Competitor> AddItemToService(Competitor item)
        {
            return await webapi.CompetitorPOSTAsync(item).HandleRequest();
        }
    }
}
