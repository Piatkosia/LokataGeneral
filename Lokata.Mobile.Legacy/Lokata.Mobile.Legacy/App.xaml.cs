using Lokata.Mobile.Legacy.Services;
using Xamarin.Forms;

namespace Lokata.Mobile.Legacy
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Register<AddressDataStore>();
            DependencyService.Register<ApproachDataStore>();
            DependencyService.Register<CategoryDataStore>();
            DependencyService.Register<CompetitionDataStore>();
            DependencyService.Register<CompetitionsDataStore>();
            DependencyService.Register<CompetitorDataStore>();
            DependencyService.Register<DocumentDataStore>();
            DependencyService.Register<InstructorDataStore>();
            DependencyService.Register<PlaceDataStore>();
            DependencyService.Register<ScoreCardDataStore>();
            DependencyService.Register<SexDataStore>();
            DependencyService.Register<TakePlaceDataStore>();
            DependencyService.Register<TargetsAndCardsPhotoDataStore>();
            DependencyService.Register<TargetsOrCardTakeDataStore>();
            DependencyService.Register<UmpireDataStore>();
            //DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
