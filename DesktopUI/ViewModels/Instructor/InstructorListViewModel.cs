using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Lokata.DataService;
using Lokata.DesktopUI.Events.Instructor;
using Lokata.DesktopUI.Events.Main;
using Lokata.Domain.Services;

using Prism.Events;

namespace Lokata.DesktopUI.ViewModels.Instructor
{
    public class InstructorListViewModel : AllViewModel<Domain.Instructor>
    {
        private readonly IEventAggregator _eventAggregator;

        private readonly IInstructorService _service;

        public InstructorListViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _service = new InstructorService(Context);
            DisplayName = "Instruktorzy";
            _eventAggregator.GetEvent<InstructorSaved>().Subscribe(LoadListSync);
        }

        private void LoadListSync(Domain.Instructor obj)
        {
            _eventAggregator.GetEvent<LoadStarted>().Publish();
            List = new ObservableCollection<Domain.Instructor>(_service.GetAll());
            _eventAggregator.GetEvent<LoadStopped>().Publish();
        }

        protected override void EditItem()
        {
            _eventAggregator.GetEvent<InstructorItemOpened>().Publish(CurrentItem);
        }

        protected override void AddItem()
        {
            _eventAggregator.GetEvent<InstructorItemOpened>().Publish(null);
        }

        protected override void SaveAsExcel()
        {
            _eventAggregator.GetEvent<InstructorListAsExcelSaved>().Publish();
        }

        protected override void SaveAsPdf()
        {
            _eventAggregator.GetEvent<InstructorListAsPdfSaved>().Publish();
        }

        protected override async Task DeleteItem()
        {
            await _service.Delete(CurrentItem.Id);
            await LoadList();
        }

        protected override async Task LoadList()
        {
            _eventAggregator.GetEvent<LoadStarted>().Publish();
            List = new ObservableCollection<Domain.Instructor>(await _service.GetAllAsync());
            _eventAggregator.GetEvent<LoadStopped>().Publish();
        }
    }
}
