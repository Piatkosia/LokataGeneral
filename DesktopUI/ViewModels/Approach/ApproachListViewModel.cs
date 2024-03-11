using System.Collections.ObjectModel;

using Lokata.DataService;
using Lokata.DesktopUI.Events.Approach;
using Lokata.DesktopUI.Events.Main;
using Lokata.Domain.Services;

using Prism.Events;

namespace Lokata.DesktopUI.ViewModels.Approach
{
    public class ApproachListViewModel : AllViewModel<Domain.Approach>
    {
        private readonly IEventAggregator _eventAggregator;

        private readonly IApproachService _service;

        public ApproachListViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _service = new ApproachService(Context);
            DisplayName = "Podejścia";
            _eventAggregator.GetEvent<ApproachSaved>().Subscribe(LoadListSync);
        }

        private void LoadListSync(Domain.Approach obj)
        {
            _eventAggregator.GetEvent<LoadStarted>().Publish();
            List = new ObservableCollection<Domain.Approach>(_service.GetAll());
            _eventAggregator.GetEvent<LoadStopped>().Publish();
        }

        protected override void EditItem()
        {
            _eventAggregator.GetEvent<ApproachItemOpened>().Publish(CurrentItem);
        }

        protected override void AddItem()
        {
            _eventAggregator.GetEvent<ApproachItemOpened>().Publish(null);
        }


        protected override void SaveAsExcel()
        {
            _eventAggregator.GetEvent<ApproachListAsExcelSaved>().Publish();
        }
    }
}
