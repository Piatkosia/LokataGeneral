using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Lokata.DataService;
using Lokata.DesktopUI.Events.Main;
using Lokata.DesktopUI.Events.Umpire;
using Lokata.Domain.Services;

using Prism.Events;

namespace Lokata.DesktopUI.ViewModels.Umpire
{
    public class UmpireListViewModel : AllViewModel<Domain.Umpire>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IUmpireService _service;

        public UmpireListViewModel(IEventAggregator eventAggregator) : base()
        {
            _eventAggregator = eventAggregator;
            _service = new UmpireService(Context);
            DisplayName = "Sędziowie";
            _eventAggregator.GetEvent<UmpireSaved>().Subscribe(LoadListSync);
        }

        private void LoadListSync(Domain.Umpire obj)
        {
            _eventAggregator.GetEvent<LoadStarted>().Publish();
            List = new ObservableCollection<Domain.Umpire>(_service.GetAll());
            _eventAggregator.GetEvent<LoadStopped>().Publish();
        }

        protected override void EditItem()
        {
            _eventAggregator.GetEvent<UmpireItemOpened>().Publish(CurrentItem);
        }

        protected override void AddItem()
        {
            _eventAggregator.GetEvent<UmpireItemOpened>().Publish(new Domain.Umpire());
        }


        protected override void SaveAsExcel()
        {
            _eventAggregator.GetEvent<UmpireListAsExcelSaved>().Publish();
        }

        protected override void SaveAsPdf()
        {
            _eventAggregator.GetEvent<UmpireListAsPdfSaved>().Publish();
        }

        protected override async Task DeleteItem()
        {
            await _service.Delete(CurrentItem.Id);
            await LoadList();
        }

        protected override async Task LoadList()
        {
            _eventAggregator.GetEvent<LoadStarted>().Publish();
            List = new ObservableCollection<Domain.Umpire>(await _service.GetAllAsync());
            _eventAggregator.GetEvent<LoadStopped>().Publish();
        }
    }
}
