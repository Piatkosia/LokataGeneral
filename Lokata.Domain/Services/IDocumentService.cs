namespace Lokata.Domain.Services
{
    public interface IDocumentService : IDataService<Document>
    {
        Task<IEnumerable<DocumentLite>> GetAllLite();
        Task<DocumentLite> GetByIdLite(int id);
    }
}
