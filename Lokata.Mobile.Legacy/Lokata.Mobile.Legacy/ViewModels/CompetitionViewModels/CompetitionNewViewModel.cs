using Lokata.Mobile.Legacy.Helpers;
using Lokata.Mobile.Legacy.ViewModels.Abstract;

namespace Lokata.Mobile.Legacy.ViewModels.CompetitionViewModels
{
    public class CompetitionNewViewModel : ANewItemViewModel<Competition>
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

        public override bool ValidateSave()
        {
            if (string.IsNullOrWhiteSpace(_name))
            {
                return false;
            }

            if (_seriesCount < 0)
            {
                return false;
            }
            if (_maxPointsPerSeries < 0)
            {
                return false;
            }

            return true;
        }

        public override Competition SetItem()
        {
            return new Competition().CopyProperties(this);
        }
    }
}
