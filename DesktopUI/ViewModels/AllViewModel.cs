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
                RaiseCanExecuteChanged();
            }
        }

        private void RaiseCanExecuteChanged()
        {
            ((BaseCommand)DeleteCommand).RaiseCanExecuteChanged();
            ((BaseCommand)EditCommand).RaiseCanExecuteChanged();
        }

        private ObservableCollection<T> _list;
        private bool _isChanged;

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
            DeleteCommand = new BaseCommand(async () => await HandleDeleteItem(), CanExecute);
            LoadCommand = new BaseCommand(async () => await LoadList());
            AddCommand = new BaseCommand(async () => await AddItem());
            EditCommand = new BaseCommand(async () => await EditItem(), CanExecute);
            LoadItemCommand = new BaseCommand(async () => await LoadItem());
            CurrentItem = default;
            RaiseCanExecuteChanged();
        }

        private bool CanExecute()
        {
            return CurrentItem != null;
        }

        private async Task HandleDeleteItem()
        {

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
