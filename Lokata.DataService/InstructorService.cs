using Lokata.DataAccess;
using Lokata.Domain;
using Lokata.Domain.Services;

namespace Lokata.DataService
{
    public class InstructorService : BaseDataService<Instructor>, IInstructorService, ILookupable
    {
        public InstructorService(DatabaseContext context) : base(context)
        {
        }

        public List<LookupItem> GetLookup()
        {
            return Context.Instructors
                .Select(x => new LookupItem()
                {
                    Id = x.Id,
                    DisplayValue = x.FullName
                }).ToList();
        }
    }
}
