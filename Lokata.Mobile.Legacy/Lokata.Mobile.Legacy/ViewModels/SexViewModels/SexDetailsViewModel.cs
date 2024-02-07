using Lokata.Mobile.Legacy.Helpers;
using Lokata.Mobile.Legacy.ViewModels.Abstract;
using Xamarin.Forms;

namespace Lokata.Mobile.Legacy.ViewModels.SexViewModels
{
    internal class SexDetailsViewModel : ADetailsViewModel<Sex>
    {
        private string _name;
        private bool _asMale;
        private bool _asFemale;


        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public bool AsMale
        {
            get => _asMale;
            set => SetProperty(ref _asMale, value);
        }

        public bool AsFemale
        {
            get => _asFemale;
            set => SetProperty(ref _asFemale, value);
        }

        public override void SetItemProperties(Sex item)
        {
            this.CopyProperties(item);
        }

        protected override async void OnEditAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(SexEditPage)}?{nameof(SexEditViewModel.ItemId)}={Id}");
        }
    }
}
