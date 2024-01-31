using Lokata.Mobile.Legacy.Services.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace Lokata.Mobile.Legacy.Services
{
    public class ScoreCardDataStore : AListDataStore<ScoreCard>
    {
        public ScoreCardDataStore()
        {
            items = webapi.ScoreCardsAllAsync().GetAwaiter().GetResult().ToList();
        }

        public override ScoreCard Find(ScoreCard item)
        {
            return items.FirstOrDefault(arg => arg.Id == item.Id);
        }

        public override async Task<ScoreCard> Find(int id)
        {
            return await webapi.ScoreCardsGETAsync(id);
        }

        public override async Task Refresh()
        {
            items = (await webapi.ScoreCardsAllAsync()).ToList();
        }

        public override async Task<bool> DeleteItemFromService(ScoreCard item)
        {
            return await webapi.ScoreCardsDELETEAsync(item.Id);
        }

        public override async Task<bool> UpdateItemInService(ScoreCard item)
        {
            return await webapi.ScoreCardsPUTAsync(item.Id, item);
        }

        public override async Task<ScoreCard> AddItemToService(ScoreCard item)
        {
            return await webapi.ScoreCardsPOSTAsync(item);
        }
    }
}
