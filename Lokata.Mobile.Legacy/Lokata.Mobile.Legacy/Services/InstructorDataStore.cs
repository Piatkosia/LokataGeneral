using Lokata.Mobile.Legacy.Services.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace Lokata.Mobile.Legacy.Services
{
    public class InstructorDataStore : AListDataStore<Instructor>
    {
        public InstructorDataStore()
        {
            items = webapi.InstructorsAllAsync().GetAwaiter().GetResult().ToList();
        }
        public override Instructor Find(Instructor item)
        {
            return items.FirstOrDefault(arg => arg.Id == item.Id);
        }

        public override async Task<Instructor> Find(int id)
        {
            return await webapi.InstructorsGETAsync(id);
        }

        public override async Task Refresh()
        {
            items = (await webapi.InstructorsAllAsync()).ToList();
        }

        public override async Task<bool> DeleteItemFromService(Instructor item)
        {
            return await webapi.InstructorsDELETEAsync(item.Id);
        }

        public override async Task<bool> UpdateItemInService(Instructor item)
        {
            return await webapi.InstructorsPUTAsync(item.Id, item);
        }

        public override async Task<Instructor> AddItemToService(Instructor item)
        {
            return await webapi.InstructorsPOSTAsync(item);
        }
    }
}
