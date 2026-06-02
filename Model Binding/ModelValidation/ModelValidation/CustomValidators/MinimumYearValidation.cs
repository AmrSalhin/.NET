using System.ComponentModel.DataAnnotations;

namespace ModelValidation.CustomValidators
{
    public class MinimumYearValidation : ValidationAttribute
    {
        private int _minimumYear = 2000;
        private string _defaultErrorMessage = "Minimum allowed year is {0}";
        public MinimumYearValidation() { }
        public MinimumYearValidation(int minimumYear)
        {
            _minimumYear = minimumYear;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                if(date.Year > _minimumYear)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? _defaultErrorMessage,_minimumYear));
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
