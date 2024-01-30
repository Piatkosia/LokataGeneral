using Lokata.Mobile.Legacy.Helpers;
using Lokata.Mobile.Legacy.Services.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace Lokata.Mobile.Legacy.Services
{
    public class CategoryDataStore : AListDataStore<Category>
    {
        public CategoryDataStore()
        {
            items = webapi.CategoryAllAsync().GetAwaiter().GetResult().ToList();
        }
        public override Category Find(Category item)
        {
            return items.FirstOrDefault(arg => arg.Id == item.Id);
        }

        public override async Task<Category> Find(int id)
        {
            return await webapi.CategoryGETAsync(id).HandleRequest();
        }

        public override async Task Refresh()
        {
            items = (await webapi.CategoryAllAsync()).ToList();
        }

        public override async Task<bool> DeleteItemFromService(Category item)
        {
            return await webapi.CategoryDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<bool> UpdateItemInService(Category item)
        {
            return await webapi.CategoryPUTAsync(item.Id, item).HandleRequest();
        }

        public override async Task<Category> AddItemToService(Category item)
        {
            return await webapi.CategoryPOSTAsync(item).HandleRequest();
        }
    }
}
