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
            RuleFor(person=>person.FirstName).NotEmpty();
            RuleFor(person=>person.LastName).NotEmpty();
            RuleFor(person=>person.Id).NotNull().NotEmpty();
        }
        
    }
}