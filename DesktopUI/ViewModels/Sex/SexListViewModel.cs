using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Lokata.DataService;
using Lokata.DesktopUI.Events.Main;
using Lokata.DesktopUI.Events.Sex;
using Lokata.Domain.Services;

using Prism.Events;

namespace Lokata.DesktopUI.ViewModels.Sex
{
    public class SexListViewModel : AllViewModel<Domain.Sex>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly ISexService _service;

        public SexListViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _service = new SexService(Context);
            DisplayName = "Płcie";
            _eventAggregator.GetEvent<SexSaved>().Subscribe(LoadListSync);
        }

        private void LoadListSync(Domain.Sex obj)
        {
            _eventAggregator.GetEvent<LoadStarted>().Publish();
            List = new ObservableCollection<Domain.Sex>(_service.GetAll());
            _eventAggregator.GetEvent<LoadStopped>().Publish();
        }

        protected override async Task LoadList()
        {
            _eventAggregator.GetEvent<LoadStarted>().Publish();
            List = new ObservableCollection<Domain.Sex>(await _service.GetAllAsync());
            _eventAggregator.GetEvent<LoadStopped>().Publish();
        }
        protected override void EditItem()
        {
            _eventAggregator.GetEvent<SexItemOpened>().Publish(CurrentItem);
        }

        protected override void AddItem()
        {
            _eventAggregator.GetEvent<SexItemOpened>().Publish(null);
        }

        protected override void SaveAsExcel()
        {
            _eventAggregator.GetEvent<SexListAsExcelSaved>().Publish();
        }

        protected override void SaveAsPdf()
        {
            _eventAggregator.GetEvent<SexListAsPdfSaved>().Publish();
        }

        protected override async Task DeleteItem()
        {
            await _service.Delete(CurrentItem.Id);
            await LoadList();
        }
    }
}
