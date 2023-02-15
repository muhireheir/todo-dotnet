using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListSmarter.Models;
using AutoMapper;

namespace ListSmarter.Repositories
{
    public class PersonRepository :IPersonRepository

    {
        private readonly IMapper _mapper;
        public PersonRepository(IMapper mapper){
            _mapper = mapper;
        }
        
        private List<Person> people = new List<Person>{
            new Person {Id=1,FirstName="Heritier",LastName="UMUHIRE"},
            new Person {Id=2,FirstName="Lenny",LastName="Pascal"},
        };

        public List<PersonDto> getAll()
        {
            
            return _mapper.Map<List<PersonDto>>(people);
        }
    }
}