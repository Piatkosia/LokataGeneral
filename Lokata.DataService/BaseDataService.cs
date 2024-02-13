using Lokata.DataAccess;
using Lokata.Domain;
using Lokata.Domain.Exceptions;
using Lokata.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Lokata.DataService
{
    public class BaseDataService<T> : IDataService<T> where T : EntityBase
    {
        protected readonly DatabaseContext Context;

        public BaseDataService(DatabaseContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Set<T>().AsNoTracking().ToListAsync();
        }

        public IQueryable<T> GetAll()
        {
            return Context.Set<T>().AsNoTracking();
        }

        public async Task<T> GetById(int id)
        {
            return await Context.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id) ?? throw new ItemNotFoundExcepion(id);
        }

        public async Task<bool> Exists(int id)
        {
            return await Context.Set<T>()
                .AsNoTracking()
                .AnyAsync(e => e.Id == id);
        }

        public async Task Create(T entity)
        {
            entity.ModifiedOn = DateTime.UtcNow;
            entity.CreatedOn = DateTime.UtcNow;
            entity.CreatedBy = "System";
            entity.ModifiedBy = "System";
            await Context.Set<T>().AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = "System";
            Context.Set<T>().Update(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            entity.IsDeleted = true;
            entity.ModifiedOn = DateTime.UtcNow;
            entity.ModifiedBy = "System";
            Context.Set<T>().Update(entity);
            await Context.SaveChangesAsync();
        }
    }
}
