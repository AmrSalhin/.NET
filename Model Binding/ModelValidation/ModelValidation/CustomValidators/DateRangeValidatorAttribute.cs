using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelValidation.CustomValidators
{
    public class DateRangeValidatorAttribute : ValidationAttribute
    {
        public String OtherPropertyName;
        string _defaultMessage = "To Date Must be After From Date";

        public DateRangeValidatorAttribute(String OtherPropertyName)
        {
            this.OtherPropertyName = OtherPropertyName;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                PropertyInfo? property = validationContext.ObjectType.GetProperty(OtherPropertyName);
                if (property == null)
                {
                    return null;
                }
                DateTime from_Date = Convert.ToDateTime(property.GetValue(validationContext.ObjectInstance));
                DateTime to_Date = (DateTime)value;
                if (to_Date < from_Date)
                {
                    return new ValidationResult(ErrorMessage ?? _defaultMessage);
                }
                return ValidationResult.Success;
            }
        }
    }
}
