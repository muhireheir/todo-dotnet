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
        
        public List<Person> people = new List<Person>{
            new Person {Id=1,FirstName="Heritier",LastName="UMUHIRE"},
            new Person {Id=2,FirstName="Lenny",LastName="Pascal"},
        };


        

        public List<PersonDto> getAll()
        {
            
            return _mapper.Map<List<PersonDto>>(people);
        }
        public void create(PersonDto person)
        {
            people.Add(_mapper.Map<Person>(person));
        }
        public void delete(int id){
            List<Person> list  = people.Where(person=>person.Id!=id).ToList();
            people.Clear();
            people.AddRange(list);
        }

        public void update(int id,PersonDto data){
            Person currentData = people.First(person=>person.Id==id);
            currentData.FirstName=data.FirstName;
            currentData.LastName = data.LastName;
        }

       public  List<Person> GetPeople()
        {
            return people;
        }

        public Person GetPerson(int id){
            return people.First(person=>person.Id==id);
        }


    }
}