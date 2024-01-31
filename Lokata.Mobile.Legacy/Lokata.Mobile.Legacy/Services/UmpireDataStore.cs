using Lokata.Mobile.Legacy.Services.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace Lokata.Mobile.Legacy.Services
{
    public class UmpireDataStore : AListDataStore<Umpire>
    {
        public UmpireDataStore()
        {
            items = webapi.UmpiresAllAsync().GetAwaiter().GetResult().ToList();
        }

        public override Umpire Find(Umpire item)
        {
            return items.FirstOrDefault(arg => arg.Id == item.Id);
        }

        public override async Task<Umpire> Find(int id)
        {
            return await webapi.UmpiresGETAsync(id);
        }

        public override async Task Refresh()
        {
            items = (await webapi.UmpiresAllAsync()).ToList();
        }

        public override async Task<bool> DeleteItemFromService(Umpire item)
        {
            return await webapi.UmpiresDELETEAsync(item.Id);
        }

        public override async Task<bool> UpdateItemInService(Umpire item)
        {
            return await webapi.UmpiresPUTAsync(item.Id, item);
        }

        public override async Task<Umpire> AddItemToService(Umpire item)
        {
            return await webapi.UmpiresPOSTAsync(item);
        }
    }
}
