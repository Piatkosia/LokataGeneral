using Lokata.Mobile.Legacy.Helpers;
using Lokata.Mobile.Legacy.Services.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace Lokata.Mobile.Legacy.Services
{
    public class ScoreCardDataStore : AListDataStore<ScoreCard>
    {
        public ScoreCardDataStore()
        {
            items = webapi.ScoreCardAllAsync().GetAwaiter().GetResult().ToList();
        }

        public override ScoreCard Find(ScoreCard item)
        {
            return items.FirstOrDefault(arg => arg.Id == item.Id);
        }

        public override async Task<ScoreCard> Find(int id)
        {
            return await webapi.ScoreCardGETAsync(id);
        }

        public override async Task Refresh()
        {
            items = (await webapi.ScoreCardAllAsync()).ToList();
        }

        public override async Task<bool> DeleteItemFromService(ScoreCard item)
        {
            return await webapi.ScoreCardDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<bool> UpdateItemInService(ScoreCard item)
        {
            return await webapi.ScoreCardPUTAsync(item.Id, item).HandleRequest();
        }

        public override async Task<ScoreCard> AddItemToService(ScoreCard item)
        {
            return await webapi.ScoreCardPOSTAsync(item);
        }
    }
}
