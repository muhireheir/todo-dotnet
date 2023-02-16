using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListSmarter.Repositories;
using FluentValidation;

namespace ListSmarter.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IValidator<PersonDto> _personValidator;

        public PersonService(IPersonRepository personRepository,IValidator<PersonDto> personValidator){
            _personRepository=personRepository;
            _personValidator=personValidator;
        }

        public List<PersonDto> getAllPeople()
        {
            return _personRepository.getAll();
        }

        public void addPerson(PersonDto person){
            var results = _personValidator.Validate(person);
            if(results.IsValid){
                _personRepository.create(person);

            }else{
                Console.WriteLine(results);
            }
        }

        public void DeletePerson(int id)
        {
            _personRepository.delete(id);
        }

        public void EditPerson(int id, PersonDto data)
        {
             _personRepository.update(id,data);
        }
    }
}