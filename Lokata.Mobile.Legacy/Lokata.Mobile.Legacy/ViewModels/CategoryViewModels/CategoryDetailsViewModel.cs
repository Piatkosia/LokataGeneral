using Lokata.Mobile.Legacy.Helpers;
using Lokata.Mobile.Legacy.ViewModels.Abstract;
using Lokata.Mobile.Legacy.Views.CategoryViews;
using Xamarin.Forms;

namespace Lokata.Mobile.Legacy.ViewModels.CategoryViewModels
{
    public class CategoryDetailsViewModel : ADetailsViewModel<Category>
    {
        private string _categoryName;
        private int _minAgeInYears = 6;
        private int? _maxAgeInYears = 120;
        private bool _forDisabled;
        private bool _forProfessional;
        private bool _forFemale;
        private bool _forMale;

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

        protected override async void OnEditAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(CategoryEditPage)}?{nameof(CategoryEditViewModel.ItemId)}={Id}");
        }
    }
}
