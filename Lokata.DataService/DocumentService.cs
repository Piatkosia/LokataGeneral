using Lokata.DataAccess;
using Lokata.Domain;
using Lokata.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Lokata.DataService
{
    public class DocumentService : BaseDataService<Document>, IDocumentService
    {
        public DocumentService(DatabaseContext context) : base(context)
        {

        }
        public async Task<IEnumerable<DocumentLite>> GetAllLite()
        {
            return await Context.Documents
                .Select(a => new DocumentLite
                {
                    Id = a.Id,
                    Name = a.Name,
                    Filename = a.Filename
                })
                .ToListAsync();
        }

        public async Task<DocumentLite> GetByIdLite(int id)
        {
            return await Context.Documents
                .Where(a => a.Id == id)
                .Select(a => new DocumentLite
                {
                    Id = a.Id,
                    Name = a.Name,
                    Filename = a.Filename
                })
                .FirstOrDefaultAsync();
        }
    }
}
