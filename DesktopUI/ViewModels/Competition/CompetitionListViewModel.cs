using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Lokata.DataService;
using Lokata.DesktopUI.Events.Competition;
using Lokata.DesktopUI.Events.Main;
using Lokata.Domain.Services;

using Prism.Events;

namespace Lokata.DesktopUI.ViewModels.Competition
{
    public class CompetitionListViewModel : AllViewModel<Domain.Competition>
    {
        private readonly IEventAggregator _eventAggregator;

        private readonly ICompetitionService _service;

        public CompetitionListViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _service = new CompetitionService(Context);
            DisplayName = "Konkurencje";
            _eventAggregator.GetEvent<CompetitionSaved>().Subscribe(LoadListSync);
        }

        private void LoadListSync(Domain.Competition obj)
        {
            _eventAggregator.GetEvent<LoadStarted>().Publish();
            List = new ObservableCollection<Domain.Competition>(_service.GetAll());
            _eventAggregator.GetEvent<LoadStopped>().Publish();
        }

        protected override void EditItem()
        {
            _eventAggregator.GetEvent<CompetitionItemOpened>().Publish(CurrentItem);
        }

        protected override void AddItem()
        {
            _eventAggregator.GetEvent<CompetitionItemOpened>().Publish(null);
        }

        protected override void SaveAsExcel()
        {
            _eventAggregator.GetEvent<CompetitionListAsExcelSaved>().Publish();
        }

        protected override void SaveAsPdf()
        {
            _eventAggregator.GetEvent<CompetitionListAsPdfSaved>().Publish();
        }

        protected override async Task DeleteItem()
        {
            await _service.Delete(CurrentItem.Id);
            await LoadList();
        }

        protected override async Task LoadList()
        {
            _eventAggregator.GetEvent<LoadStarted>().Publish();
            List = new ObservableCollection<Domain.Competition>(await _service.GetAllAsync());
            _eventAggregator.GetEvent<LoadStopped>().Publish();
        }
    }
}
