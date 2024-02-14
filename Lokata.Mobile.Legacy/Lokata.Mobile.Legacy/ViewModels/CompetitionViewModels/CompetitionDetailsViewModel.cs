using Lokata.Mobile.Legacy.Helpers;
using Lokata.Mobile.Legacy.ViewModels.Abstract;
using Lokata.Mobile.Legacy.Views.CompetitionViews;
using Xamarin.Forms;

namespace Lokata.Mobile.Legacy.ViewModels.CompetitionViewModels
{
    public class CompetitionDetailsViewModel : ADetailsViewModel<Competition>
    {
        private string _name;
        private int? _seriesCount;
        private int? _maxPointsPerSeries;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        //null means unlimited
        public int? SeriesCount
        {
            get => _seriesCount;
            set => SetProperty(ref _seriesCount, value);
        }

        //null means unlimited
        public int? MaxPointsPerSeries
        {
            get => _maxPointsPerSeries;
            set => SetProperty(ref _maxPointsPerSeries, value);
        }

        public override void SetItemProperties(Competition item)
        {
            this.CopyProperties(item);
        }

        protected override async void OnEditAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(CompetitionEditPage)}?{nameof(CompetitionEditViewModel.ItemId)}={Id}");
        }
    }
}
