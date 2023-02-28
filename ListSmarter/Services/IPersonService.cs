using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListSmarter.Services
{
    public interface IPersonService
    {
        List<PersonDto> getAllPeople();

        PersonDto addPerson(PersonDto person);
        void DeletePerson(int id);
        void EditPerson(int id,PersonDto data);
    }


}