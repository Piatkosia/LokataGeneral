namespace Lokata.Domain.Services
{
    public interface IDocumentService : IDataService<Document>
    {
        Task<IEnumerable<DocumentLite>> GetAllLite();
    }
}
