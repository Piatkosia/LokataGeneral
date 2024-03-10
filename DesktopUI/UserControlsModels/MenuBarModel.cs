using System.Windows.Input;

using Lokata.DesktopUI.Events.Address;
using Lokata.DesktopUI.Events.Competition;
using Lokata.DesktopUI.Events.Instructor;
using Lokata.DesktopUI.Events.Place;
using Lokata.DesktopUI.Events.Sex;
using Lokata.DesktopUI.Events.Umpire;
using Lokata.DesktopUI.Helpers;

using Prism.Events;

namespace Lokata.DesktopUI.UserControlsModels
{
    public class MenuBarModel
    {
        private readonly IEventAggregator _eventAggregator;
        public ICommand AddressCommand { get; set; }
        public ICommand UmpireCommand { get; set; }

        public ICommand CompetitionCommand { get; set; }

        public ICommand InstructorCommand { get; set; }

        public ICommand PlaceCommand { get; set; }

        public ICommand SexCommand { get; set; }

        public MenuBarModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            AddressCommand = new BaseCommand(OnAddress);
            UmpireCommand = new BaseCommand(OnUmpire);
            CompetitionCommand = new BaseCommand(OnCompetition);
            InstructorCommand = new BaseCommand(OnInstructor);
            PlaceCommand = new BaseCommand(OnPlace);
            SexCommand = new BaseCommand(OnSex);
        }

        private void OnSex()
        {
            _eventAggregator.GetEvent<SexListOpened>().Publish();
        }

        private void OnPlace()
        {
            _eventAggregator.GetEvent<PlaceListOpened>().Publish();
        }

        private void OnInstructor()
        {
            _eventAggregator.GetEvent<InstructorListOpened>().Publish();
        }

        private void OnCompetition()
        {
            _eventAggregator.GetEvent<CompetitionListOpened>().Publish();
        }

        private void OnUmpire()
        {
            _eventAggregator.GetEvent<UmpireListOpened>().Publish();
        }

        private void OnAddress()
        {
            _eventAggregator.GetEvent<AddressListOpened>().Publish();
        }
    }
}
