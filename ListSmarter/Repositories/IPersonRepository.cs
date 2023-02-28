using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListSmarter.Models;
namespace ListSmarter.Repositories
{
    public interface IPersonRepository
    {
        List<Person> GetPeople();
        List<PersonDto> GetAll();
        PersonDto Create(PersonDto person);
        void Delete(int id);
        PersonDto Update(int id,PersonDto data);

        Person GetPerson(int id);
    
        
    }
}