using System.ComponentModel.DataAnnotations;

namespace Lokata.Domain.DataAnnotations
{
    public class NotPastDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime)
            {
                DateTime dateValue = (DateTime)value;
                return dateValue > DateTime.Now;
            }
            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"Pole {name} nie może być datą z przeszłości.";
        }
    }
}
