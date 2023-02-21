using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Validation
{
    public class MustBeA: ValidationAttribute
    {


        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (value !=null &&  !value.ToString().ToLower().Contains("a"))
            {
                return new ValidationResult("mustbe a");
            }
            return ValidationResult.Success; 
        }

    }
}
