using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lokata.Mobile.Legacy.Services.Abstractions
{
    public abstract class AListDataStore<T> : ADataStore, IDataStore<T> where T : class
    {
        public List<T> items;
        public AListDataStore()
            : base()
        {

        }

        public async Task<bool> AddItemAsync(T item)
        {
            await AddItemToService(item);
            await Refresh();
            return await Task.FromResult(true);
        }
        public abstract T Find(T item);
        public abstract Task<T> Find(int id);
        public abstract Task Refresh();
        public abstract Task<bool> DeleteItemFromService(T item);
        public abstract Task<bool> UpdateItemInService(T item);
        public abstract Task<T> AddItemToService(T item);

        public async Task<bool> UpdateItemAsync(T item)
        {
            await UpdateItemInService(item);
            await Refresh();

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = await Find(id);
            await DeleteItemFromService(oldItem);
            await Refresh();

            return await Task.FromResult(true);
        }

        public async Task<T> GetItemAsync(int id)
        {
            return await Find(id);
        }

        public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            await Refresh();
            return await Task.FromResult(items);
        }
    }
}
