using Lokata.Mobile.Legacy.Helpers;
using Lokata.Mobile.Legacy.Services.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace Lokata.Mobile.Legacy.Services
{
    public class CompetitionDataStore : AListDataStore<Competition>
    {
        public CompetitionDataStore()
        {
            items = webapi.CompetitionAllAsync().GetAwaiter().GetResult().ToList();
        }
        public override Competition Find(Competition item)
        {
            return items.FirstOrDefault(arg => arg.Id == item.Id);
        }

        public override Task<Competition> Find(int id)
        {
            return webapi.CompetitionGETAsync(id);
        }

        public override async Task Refresh()
        {
            items = (await webapi.CompetitionAllAsync()).ToList();
        }

        public override async Task<bool> DeleteItemFromService(Competition item)
        {
            return await webapi.CompetitionDELETEAsync(item.Id).HandleRequest();
        }

        public override Task<bool> UpdateItemInService(Competition item)
        {
            return webapi.CompetitionPUTAsync(item.Id, item).HandleRequest();
        }

        public override Task<Competition> AddItemToService(Competition item)
        {
            return webapi.CompetitionPOSTAsync(item).HandleRequest();
        }
    }
}
