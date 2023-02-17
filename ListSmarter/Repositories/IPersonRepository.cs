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
        List<PersonDto> getAll();
        void create(PersonDto person);
        void delete(int id);
        void update(int id,PersonDto data);

        Person GetPerson(int id);
    
        
    }
}