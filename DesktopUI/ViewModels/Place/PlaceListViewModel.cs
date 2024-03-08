using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Lokata.DataService;
using Lokata.DesktopUI.Events.Main;
using Lokata.DesktopUI.Events.Place;
using Lokata.Domain.Services;

using Prism.Events;

namespace Lokata.DesktopUI.ViewModels.Place
{
    public class PlaceListViewModel : AllViewModel<Domain.Place>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IPlaceService _service;

        public PlaceListViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _service = new PlaceService(Context);
            DisplayName = "Miejsca";
            _eventAggregator.GetEvent<PlaceSaved>().Subscribe(LoadListSync);
        }

        private void LoadListSync(Domain.Place obj)
        {
            _eventAggregator.GetEvent<LoadStarted>().Publish();
            List = new ObservableCollection<Domain.Place>(_service.GetAllWithDependenciesSync());
            _eventAggregator.GetEvent<LoadStopped>().Publish();
        }

        protected override async Task LoadList()
        {
            _eventAggregator.GetEvent<LoadStarted>().Publish();
            List = new ObservableCollection<Domain.Place>(await _service.GetAllWithDependencies());
            _eventAggregator.GetEvent<LoadStopped>().Publish();
        }

        protected override void EditItem()
        {
            _eventAggregator.GetEvent<PlaceItemOpened>().Publish(CurrentItem);
        }

        protected override void AddItem()
        {
            _eventAggregator.GetEvent<PlaceItemOpened>().Publish(null);
        }

        protected override void SaveAsExcel()
        {
            _eventAggregator.GetEvent<PlaceListAsExcelSaved>().Publish();
        }

        protected override void SaveAsPdf()
        {
            _eventAggregator.GetEvent<PlaceListAsPdfSaved>().Publish();
        }

        protected override async Task DeleteItem()
        {
            await _service.Delete(CurrentItem.Id);
            await LoadList();
        }
    }
}
