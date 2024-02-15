using Lokata.Mobile.Legacy.Helpers;
using Lokata.Mobile.Legacy.Services;
using Lokata.Mobile.Legacy.ViewModels.Abstract;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Lokata.Mobile.Legacy.ViewModels.CompetitorViewModels
{
    public class CompetitorEditViewModel : AEditItemViewModel<Competitor>
    {
        private DateTime? _dateOfBirth;
        private int? _age;
        private bool? _isDisabledPerson;
        private bool? _professional;
        private int? _sexId;
        private string _fullName;
        private Sex _sex;
        private ObservableCollection<Sex> _sexList;

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

        public Sex SelectedSex
        {
            get => _sex;
            set => SetProperty(ref _sex, value);
        }

        public ObservableCollection<Sex> SexList
        {
            get => _sexList;
            set => SetProperty(ref _sexList, value);
        }

        public override async void SetItemProperties(Competitor item)
        {
            this.CopyProperties(item);
            if (item.DateOfBirth.HasValue)
            {
                DateOfBirth = item.DateOfBirth.Value.Date;
                Age = DateTime.Now.Year - item.DateOfBirth.Value.Year;
            }
            await AssignList();
        }

        private async Task AssignList()
        {
            var datastore = new SexDataStore();
            var items = await datastore.GetItemsAsync(true);
            SexList = new ObservableCollection<Sex>(items);
            SelectedSex = SexList.FirstOrDefault(x => x.Id == SexId);
        }

        public override bool ValidateSave()
        {
            if (DateOfBirth > DateTime.Now)
            {
                return false;
            }

            if (Age < 4)
            {
                return false;
            }

            if (Age > 120)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(FullName))
            {
                return false;
            }

            return true;
        }

        public override Competitor SetItem()
        {
            var result = new Competitor().CopyProperties(this);
            result.SexId = SelectedSex.Id;
            result.DateOfBirth = DateOfBirth;
            return result;
        }
    }
}
