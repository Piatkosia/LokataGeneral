using Lokata.Mobile.Legacy.Helpers;
using Lokata.Mobile.Legacy.ViewModels.Abstract;

namespace Lokata.Mobile.Legacy.ViewModels.SexViewModels
{
    public class SexNewViewModel : ANewItemViewModel<Sex>
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
        public override bool ValidateSave()
        {
            return !string.IsNullOrEmpty(Name);
        }

        public override Sex SetItem()
        {
            return new Sex().CopyProperties(this);
        }
    }
}
