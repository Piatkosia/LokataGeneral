﻿namespace Lokata.Domain.Services
{
    public interface IInstructorDocumentService : IDataService<InstructorDocument>
    {
        Task<IEnumerable<InstructorDocument>> GetAllWithDependencies();
    }
}
