using Lokata.Mobile.Legacy.Services.Abstractions;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Lokata.Mobile.Legacy.ViewModels.Abstract
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public abstract class ADetailsViewModel<T> : BaseViewModel
    {
        protected int itemId;
        public int Id { get; set; }
        public IDataStore<T> DataStore => DependencyService.Get<IDataStore<T>>();
        public ADetailsViewModel()
        {
            DeleteCommand = new Command(OnDelete);
            EditCommand = new Command(OnEditAsync);
            CancelCommand = new Command(OnCancel);
        }
        public Command DeleteCommand { get; }
        public Command EditCommand { get; }
        public Command CancelCommand { get; }
        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }
        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                SetItemProperties(item);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        public abstract void SetItemProperties(T item);
        private async void OnDelete()
        {
            await DataStore.DeleteItemAsync(ItemId);
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
        protected abstract void OnEditAsync();
    }
}
