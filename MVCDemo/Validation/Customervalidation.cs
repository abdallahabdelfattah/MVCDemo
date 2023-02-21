using FluentValidation;
using MVCDemo.Models;
using System;

namespace MVCDemo.Validation
{
    public class Customervalidation: AbstractValidator<Customer>
    {

        public Customervalidation()
        {
            RuleFor(a=>a.FirstName).NotEmpty();

            RuleFor(a => a.FirstName).MinimumLength(5);

            

        }
    }
}
