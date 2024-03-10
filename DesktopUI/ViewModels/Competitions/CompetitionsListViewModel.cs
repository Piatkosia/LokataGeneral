using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Lokata.DataService;
using Lokata.DesktopUI.Events.Competitions;
using Lokata.DesktopUI.Events.Main;
using Lokata.Domain.Services;

using Prism.Events;

namespace Lokata.DesktopUI.ViewModels.Competitions
{
    public class CompetitionsListViewModel : AllViewModel<Domain.Competitions>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly ICompetitionsService _service;

        public CompetitionsListViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _service = new CompetitionsService(Context);
            DisplayName = "Zawody";
            _eventAggregator.GetEvent<CompetitionsSaved>().Subscribe(LoadListSync);
        }

        private void LoadListSync(Domain.Competitions competitions)
        {
            _eventAggregator.GetEvent<LoadStarted>().Publish();
            List = new ObservableCollection<Domain.Competitions>(_service.GetAll());
            _eventAggregator.GetEvent<LoadStopped>().Publish();
        }

        protected override void EditItem()
        {
            _eventAggregator.GetEvent<CompetitionsItemOpened>().Publish(CurrentItem);
        }

        protected override void AddItem()
        {
            _eventAggregator.GetEvent<CompetitionsItemOpened>().Publish(null);
        }

        protected override void SaveAsExcel()
        {
            _eventAggregator.GetEvent<CompetitionsListAsExcelSaved>().Publish();
        }

        protected override void SaveAsPdf()
        {
            _eventAggregator.GetEvent<CompetitionsListAsPdfSaved>().Publish();
        }

        protected override async Task DeleteItem()
        {
            await _service.Delete(CurrentItem.Id);
            await LoadList();
        }

        protected override async Task LoadList()
        {
            _eventAggregator.GetEvent<LoadStarted>().Publish();
            List = new ObservableCollection<Domain.Competitions>(await _service.GetAllAsync());
            _eventAggregator.GetEvent<LoadStopped>().Publish();
        }
    }
}
