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
        public ICommand SaveAsPdfCommand { get; set; }
        public ICommand SaveAsExcelCommand { get; set; }

        public AllViewModel()
        {
            DeleteCommand = new BaseCommand(async () => await HandleDeleteItem(), CanExecute);
            LoadCommand = new BaseCommand(async () => await LoadList());
            AddCommand = new BaseCommand(AddItem);
            EditCommand = new BaseCommand(EditItem, CanExecute);
            SaveAsPdfCommand = new BaseCommand(SaveAsPdf);
            SaveAsExcelCommand = new BaseCommand(SaveAsExcel);
            CurrentItem = default;
            RaiseCanExecuteChanged();
        }

        protected virtual void SaveAsExcel()
        {

        }

        protected virtual void SaveAsPdf()
        {

        }

        private bool CanExecute()
        {
            return CurrentItem != null;
        }

        private async Task HandleDeleteItem()
        {

        }

        protected virtual void EditItem()
        {
            return;
        }

        protected virtual void AddItem()
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
