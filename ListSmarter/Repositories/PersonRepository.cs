using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListSmarter.Models;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using ListSmarter.db;

namespace ListSmarter.Repositories
{
    public class PersonRepository : IPersonRepository

    {
        private readonly IMapper _mapper;
        public PersonRepository(IMapper mapper)
        {
            _mapper = mapper;
        }


        public List<PersonDto> GetAll()
        {

            return _mapper.Map<List<PersonDto>>(TemporaryDatabase.People);
        }
        public PersonDto Create(PersonDto person)
        {
            Person newPerson = _mapper.Map<Person>(person);
            newPerson.Id = TemporaryDatabase.People.Any() ? TemporaryDatabase.People.Max(i => i.Id) + 1 : 1;
            TemporaryDatabase.People.Add(_mapper.Map<Person>(newPerson));
            return person;
        }
        public void Delete(int id)
        {
            Person PersonToremove = TemporaryDatabase.People.First(person => person.Id != id);
            TemporaryDatabase.People.Remove(PersonToremove);
        }

        public PersonDto Update(int id, PersonDto data)
        {
            Person currentData = TemporaryDatabase.People.First(person => person.Id == id);
            currentData.FirstName = data.FirstName;
            currentData.LastName = data.LastName;
           return  _mapper.Map<PersonDto>(currentData);

        }

        public List<Person> GetPeople()
        {
            return TemporaryDatabase.People;
        }

        public Person GetPerson(int id)
        {
            return TemporaryDatabase.People.First(person => person.Id == id);
        }


    }
}