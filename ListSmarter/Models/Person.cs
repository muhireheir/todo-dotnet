using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListSmarter.Models
{
    public class Person:IValidatableObject
    {   
        [Required]
        public int Id {get;set;}
        [Required]
        public string? FirstName {get;set;}
        [Required]
        public string? LastName {get;set;}

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
              var results = new List<ValidationResult>();
              return results;
        }
    }
}