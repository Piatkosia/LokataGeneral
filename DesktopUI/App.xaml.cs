using System.Windows;

using Lokata.DataService;
using Lokata.DesktopUI;
using Lokata.DesktopUI.UserControlsModels;
using Lokata.DesktopUI.ViewModels;
using Lokata.DesktopUI.ViewModels.Address;
using Lokata.DesktopUI.Views.Services;
using Lokata.Domain.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Prism.Events;

namespace DesktopUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider { get; private set; }
        public IConfiguration Configuration { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
            var window = ServiceProvider.GetRequiredService<MainWindow>();
            var viewModel = ServiceProvider.GetRequiredService<MainWindowViewModel>();
            window.DataContext = viewModel;
            MainWindow = window;
            window.Show();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IApproachService, ApproachService>();
            services.AddScoped<ITargetsAndCardsPhotoService, TargetsAndCardsPhotoService>();
            services.AddScoped<ITargetsOrCardTakeService, TargetsOrCardTakeService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICompetitionService, CompetitionService>();
            services.AddScoped<ICompetitionsService, CompetitionsService>();
            services.AddScoped<ICompetitorService, CompetitorService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IInstructorService, InstructorService>();
            services.AddScoped<IPlaceService, PlaceService>();
            services.AddScoped<IScoreCardService, ScoreCardService>();
            services.AddScoped<ISexService, SexService>();
            services.AddScoped<ITakePlaceService, TakePlaceService>();
            services.AddScoped<ITargetsAndCardsPhotoService, TargetsAndCardsPhotoService>();
            services.AddScoped<ITargetsOrCardTakeService, TargetsOrCardTakeService>();
            services.AddScoped<IUmpireService, UmpireService>();
            services.AddScoped<IInstructorDocumentService, InstructorDocumentService>();
            services.AddSingleton<IEventAggregator, EventAggregator>();
            services.AddScoped<MainWindowViewModel>();
            services.AddScoped<MainWindow>();
            services.AddScoped<AddressViewModel>();
            services.AddScoped<MenuBarModel>();

            services.AddScoped<IMessageDialogService, MessageDialogService>();
        }
    }
}
