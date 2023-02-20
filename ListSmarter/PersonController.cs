using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListSmarter.Services;

namespace ListSmarter
{
    public class PersonController
    {

        private readonly IPersonService _personService;
        public PersonController(IPersonService personService){
            this._personService = personService;
        }
        
        public List<PersonDto> getAllPeople(){
            return _personService.getAllPeople();
        }
        public void createPeople(PersonDto person){
            _personService.addPerson(person);
        }

        public void DeletePerson(int id){
            try
            {
                _personService.DeletePerson(id);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        public void UpdatePerson(int id,PersonDto data){
            _personService.EditPerson(id,data);
        }
    }
}
