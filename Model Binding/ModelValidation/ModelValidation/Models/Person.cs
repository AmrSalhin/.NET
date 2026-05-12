using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Person name cannot be empty or null")]
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
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
