using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListSmarter.Models;

namespace ListSmarter.Services
{
    public interface IPersonService
    {
        List<PersonDto> getAllPeople();

        PersonDto addPerson(PersonDto person);
        void DeletePerson(int id);
        PersonDto EditPerson(int id,PersonDto data);
        
        PersonDto GetOne(int id);
        Person GetPerson(int id);
    }


}