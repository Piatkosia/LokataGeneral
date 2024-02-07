using Lokata.Mobile.Legacy.Helpers;
using Lokata.Mobile.Legacy.Services.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace Lokata.Mobile.Legacy.Services
{
    public class CompetitionsDataStore : AListDataStore<Competitions>
    {
        public CompetitionsDataStore()
        {
            items = webapi.CompetitionsAllAsync().GetAwaiter().GetResult().ToList();
        }

        public override Competitions Find(Competitions item)
        {
            return items.FirstOrDefault(arg => arg.Id == item.Id);
        }

        public override Task<Competitions> Find(int id)
        {
            return webapi.CompetitionsGETAsync(id);
        }

        public override async Task Refresh()
        {
            items = (await webapi.CompetitionsAllAsync()).ToList();
        }

        public override async Task<bool> DeleteItemFromService(Competitions item)
        {
            return await webapi.CompetitionsDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<bool> UpdateItemInService(Competitions item)
        {
            return await webapi.CompetitionsPUTAsync(item.Id, item).HandleRequest();
        }

        public override async Task<Competitions> AddItemToService(Competitions item)
        {
            return await webapi.CompetitionsPOSTAsync(item);
        }
    }
}
