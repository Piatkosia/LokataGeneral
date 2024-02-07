using Lokata.Mobile.Legacy.Helpers;
using Lokata.Mobile.Legacy.Services.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace Lokata.Mobile.Legacy.Services
{
    public class DocumentDataStore : AListDataStore<Document>
    {
        public DocumentDataStore()
        {
            items = webapi.DocumentAllAsync().GetAwaiter().GetResult().ToList();
        }
        public override Document Find(Document item)
        {
            return items.FirstOrDefault(arg => arg.Id == item.Id);
        }

        public override async Task<Document> Find(int id)
        {
            return await webapi.DocumentGETAsync(id);
        }

        public override async Task Refresh()
        {
            items = (await webapi.DocumentAllAsync()).ToList();
        }

        public override async Task<bool> DeleteItemFromService(Document item)
        {
            return await webapi.DocumentDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<bool> UpdateItemInService(Document item)
        {
            return await webapi.DocumentPUTAsync(item.Id, item).HandleRequest();
        }

        public override async Task<Document> AddItemToService(Document item)
        {
            return await webapi.DocumentPOSTAsync(item);
        }
    }
}
