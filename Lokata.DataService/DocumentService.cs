using Lokata.DataAccess;
using Lokata.Domain;
using Lokata.Domain.Services;

namespace Lokata.DataService
{
    public class DocumentService : BaseDataService<Document>, IDocumentService
    {
        public DocumentService(DatabaseContext context) : base(context)
        {
        }
    }
}
