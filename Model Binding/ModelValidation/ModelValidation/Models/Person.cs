using ModelValidation.CustomValidators;
using System.ComponentModel.DataAnnotations;


namespace ModelValidation.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Person name cannot be empty or null")]
        [StringLength(40,MinimumLength = 3,ErrorMessage = "{0} length must be between {2} and {1}")]
        [Display(Name ="Person Name")]
        [RegularExpression("^[A-Za-z .]+$", ErrorMessage = "{0} must be only alphabet, space or dot")]
        public string? Name { get; set; }

        [MinimumYearValidation(2002,ErrorMessage ="Minimum allowed year is {0}")]
        public DateTime? Date { get; set; }

        public DateTime? FromDate {  get; set; }

        [DateRangeValidatorAttribute("FromDate",ErrorMessage = "To Date Must be grater than from date")]
        public DateTime? ToDate { get; set; }

        [Required(ErrorMessage = "{0} Can't be Blank")]
        [EmailAddress(ErrorMessage = "{0} should be email")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "{0} should be digits")]
        public string? Phone { get; set; }

        [Required(ErrorMessage ="{0} Can't be Blank")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "{0} Can't be Blank")]
        [Compare("Password", ErrorMessage = "{0} and {1} dosn't match")]
        [Display(Name = "Re-enter password")]
        public string? ConfirmPassword { get; set; }
        [Range(0,999.99,ErrorMessage = "{0} should be between {1} and {2}")]
        public double? Price { get; set; }

        public override string ToString()
        {
            return $"Person object - Person Name {Name}" +
                $"Email {Email} Phone {Phone}" +
                $"Password {Password} Confirm Password {ConfirmPassword}" +
                $"Price {Price}";
        }
    }
}
