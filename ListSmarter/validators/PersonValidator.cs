using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace ListSmarter.validators
{
    public class PersonValidator:AbstractValidator<PersonDto>
    {

        public PersonValidator(){
            RuleFor(person=>person.FirstName).NotNull().NotEmpty();
            RuleFor(person=>person.LastName).NotNull().NotEmpty();
        }
        
    }
}