using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListSmarter.Repositories;

namespace ListSmarter.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository){
            _personRepository=personRepository;
        }

        public List<PersonDto> getAllPeople()
        {
            return _personRepository.getAll();
        }
    }
}