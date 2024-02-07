using Lokata.Mobile.Legacy.ViewModels.Abstract;
using System;

namespace Lokata.Mobile.Legacy.ViewModels.ApproachViewModels
{
    public class ApproachDetailsViewModel : ADetailsViewModel<Approach>
    {
        public int? CompetitionId { get; set; }

        public int? CompetitionsId { get; set; }

        public int? InstructorId { get; set; }

        public int? UmpireId { get; set; }

        public override void SetItemProperties(Approach item)
        {
            throw new NotImplementedException();
        }

        protected override void OnEditAsync()
        {
            throw new NotImplementedException();
        }
    }
}
