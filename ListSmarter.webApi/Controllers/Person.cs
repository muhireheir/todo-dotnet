using ListSmarter.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListSmarter.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Person : ControllerBase
    {   private readonly IPersonService _personService;
        public Person(IPersonService personService) { 
            _personService = personService;
        
        }
        [HttpGet]
        public IList<PersonDto>GetPeople()
        {
          return _personService.getAllPeople();
        }
        [HttpPost]
        public PersonDto PostPeople(PersonDto data) {
            return _personService.addPerson(data);
        }
    }
}
