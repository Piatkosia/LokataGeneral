using System.Linq;
using Xamarin.Forms;

namespace Lokata.Mobile.Legacy.Views
{
    public class NumericValidationBehavior : Behavior<Entry>
    {
        public int Max { get; set; }
        public int Min { get; set; }

        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            if (args.NewTextValue == args.OldTextValue) return;

            bool isValid = string.IsNullOrEmpty(args.NewTextValue) || args.NewTextValue.All(x => char.IsDigit(x));
            //if (isValid)
            //{

            //    int value = int.Parse(args.NewTextValue);
            //    if (value < Min)
            //    {
            //        isValid = false;
            //    }

            //    if (value > Max)
            //    {
            //        isValid = false;
            //    }
            //}
            ((Entry)sender).Text =
                isValid
                    ? args.NewTextValue
                    : args.OldTextValue; // args.NewTextValue.Remove(args.NewTextValue.Length - 1);
            return;


            ((Entry)sender).Text = args.NewTextValue;
        }
    }
}
