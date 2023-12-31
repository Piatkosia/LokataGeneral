using Lokata.DataAccess;
using Lokata.Domain;
using Lokata.Domain.Services;

namespace Lokata.DataService
{
    public class InstructorService : BaseDataService<Instructor>, IInstructorService
    {
        public InstructorService(DatabaseContext context) : base(context)
        {
        }
    }
}
