using Lokata.Mobile.Legacy.Helpers;
using Lokata.Mobile.Legacy.Services;
using Lokata.Mobile.Legacy.ViewModels.Abstract;
using Lokata.Mobile.Legacy.Views.CompetitorViews;
using System;
using Xamarin.Forms;

namespace Lokata.Mobile.Legacy.ViewModels.CompetitorViewModels
{
    public class CompetitorDetailsViewModel : ADetailsViewModel<Competitor>
    {
        private DateTime? _dateOfBirth;
        private int? _age;
        private bool? _isDisabledPerson;
        private bool? _professional;
        private int? _sexId;
        private string _fullName;
        private Sex _sex = null;

        public DateTime? DateOfBirth
        {
            get => _dateOfBirth;
            set => SetProperty(ref _dateOfBirth, value);
        }

        public int? Age
        {
            get => _age;
            set => SetProperty(ref _age, value);
        }

        public bool? IsDisabledPerson
        {
            get => _isDisabledPerson;
            set => SetProperty(ref _isDisabledPerson, value);
        }

        public bool? Professional
        {
            get => _professional;
            set => SetProperty(ref _professional, value);
        }

        public int? SexId
        {
            get => _sexId;
            set => SetProperty(ref _sexId, value);
        }

        public string FullName
        {
            get => _fullName;
            set => SetProperty(ref _fullName, value);
        }

        public Sex Sex
        {
            get => _sex;
            set => SetProperty(ref _sex, value);
        }

        public override async void SetItemProperties(Competitor item)
        {
            this.CopyProperties(item);
            if (item.DateOfBirth.HasValue)
            {
                DateOfBirth = item.DateOfBirth.Value.Date;
                Age = DateTime.Now.Year - item.DateOfBirth.Value.Year;
            }
            if (item.SexId.HasValue)
            {
                var datastore = new SexDataStore();
                await datastore.Refresh();
                Sex = await datastore.GetItemAsync(item.SexId.Value);
            }
        }

        protected override async void OnEditAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(CompetitorEditPage)}?{nameof(CompetitorEditViewModel.ItemId)}={Id}");
        }
    }
}
