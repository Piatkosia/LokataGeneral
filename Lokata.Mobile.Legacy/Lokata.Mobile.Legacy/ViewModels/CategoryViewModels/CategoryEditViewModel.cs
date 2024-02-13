using Lokata.Mobile.Legacy.Helpers;
using Lokata.Mobile.Legacy.ViewModels.Abstract;

namespace Lokata.Mobile.Legacy.ViewModels.CategoryViewModels
{
    public class CategoryEditViewModel : AEditItemViewModel<Category>
    {
        private string _categoryName;
        private int _minAgeInYears = 6;
        private int? _maxAgeInYears = 120;
        private bool _forDisabled;
        private bool _forProfessional;
        private bool _forFemale;
        private bool _forMale;

        public CategoryEditViewModel() : base()
        {

        }
        public string CategoryName
        {
            get => _categoryName;
            set => SetProperty(ref _categoryName, value);
        }

        public int MinAgeInYears
        {
            get => _minAgeInYears;
            set => SetProperty(ref _minAgeInYears, value);
        }

        public int? MaxAgeInYears
        {
            get => _maxAgeInYears;
            set => SetProperty(ref _maxAgeInYears, value);
        }

        public bool ForDisabled
        {
            get => _forDisabled;
            set => SetProperty(ref _forDisabled, value);
        }

        public bool ForProfessional
        {
            get => _forProfessional;
            set => SetProperty(ref _forProfessional, value);
        }

        public bool ForFemale
        {
            get => _forFemale;
            set => SetProperty(ref _forFemale, value);
        }

        public bool ForMale
        {
            get => _forMale;
            set => SetProperty(ref _forMale, value);
        }

        public override void SetItemProperties(Category item)
        {
            this.CopyProperties(item);
        }

        public override bool ValidateSave()
        {
            if (string.IsNullOrWhiteSpace(_categoryName))
            {
                return false;
            }

            if (_minAgeInYears < 4)
            {
                return false;
            }

            if (_maxAgeInYears < _minAgeInYears)
            {
                return false;
            }

            if (_maxAgeInYears > 120)
            {
                return false;
            }
            return true;
        }

        public override Category SetItem()
        {
            return new Category().CopyProperties(this);
        }
    }
}
