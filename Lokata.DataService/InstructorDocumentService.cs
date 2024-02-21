using Lokata.DataAccess;
using Lokata.Domain;
using Lokata.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Lokata.DataService
{
    public class InstructorDocumentService : BaseDataService<InstructorDocument>, IInstructorDocumentService
    {
        public InstructorDocumentService(DatabaseContext context) : base(context)
        {
        }

        public async Task<IEnumerable<InstructorDocument>> GetAllWithDependencies()
        {
            return await Context.InstructorDocuments
                .Include(a => a.Instructor)
                .Include(a => a.Document)
                .Where(x => !x.IsDeleted)
                .ToListAsync();
        }

        public async Task<InstructorDocument> GetByIdWithDependencies(int id)
        {
            return await Context.InstructorDocuments
                .Include(a => a.Instructor)
                .Include(a => a.Document)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

    }
}
