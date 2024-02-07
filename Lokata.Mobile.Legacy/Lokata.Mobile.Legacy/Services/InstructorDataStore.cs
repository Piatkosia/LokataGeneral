using Lokata.Mobile.Legacy.Helpers;
using Lokata.Mobile.Legacy.Services.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace Lokata.Mobile.Legacy.Services
{
    public class InstructorDataStore : AListDataStore<Instructor>
    {
        public InstructorDataStore()
        {
            items = webapi.InstructorAllAsync().GetAwaiter().GetResult().ToList();
        }
        public override Instructor Find(Instructor item)
        {
            return items.FirstOrDefault(arg => arg.Id == item.Id);
        }

        public override async Task<Instructor> Find(int id)
        {
            return await webapi.InstructorGETAsync(id);
        }

        public override async Task Refresh()
        {
            items = (await webapi.InstructorAllAsync()).ToList();
        }

        public override async Task<bool> DeleteItemFromService(Instructor item)
        {
            return await webapi.InstructorDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<bool> UpdateItemInService(Instructor item)
        {
            return await webapi.InstructorPUTAsync(item.Id, item).HandleRequest();
        }

        public override async Task<Instructor> AddItemToService(Instructor item)
        {
            return await webapi.InstructorPOSTAsync(item);
        }
    }
}
