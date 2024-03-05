using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

using Lokata.DesktopUI.Helpers;

namespace Lokata.DesktopUI.ViewModels
{
    public class AllViewModel<T> : WorkspaceViewModel
    {
        private T _currentItem;

        public T CurrentItem
        {
            get => _currentItem;
            set
            {
                _currentItem = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<T> _list;
        public ObservableCollection<T> List
        {
            get => _list;
            set
            {
                _list = value;
                OnPropertyChanged();
            }
        }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand LoadItemCommand { get; set; }
        public AllViewModel()
        {
            DeleteCommand = new BaseCommand(async () => await DeleteItem());
            LoadCommand = new BaseCommand(async () => await LoadList());
            AddCommand = new BaseCommand(async () => await AddItem());
            EditCommand = new BaseCommand(async () => await EditItem());
            LoadItemCommand = new BaseCommand(async () => await LoadItem());
        }

        protected virtual async Task EditItem()
        {
            return;
        }

        protected virtual async Task AddItem()
        {
            return;
        }

        protected virtual async Task LoadItem()
        {
            return;
        }


        protected virtual async Task DeleteItem()
        {
            OnRequestClose();
        }


        protected virtual async Task LoadList()
        {
            return;
        }
    }
}
