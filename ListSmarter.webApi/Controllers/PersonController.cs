using Microsoft.AspNetCore.Mvc;
using ListSmarter.Services;
using ListSmarter.Dtos;
using Microsoft.AspNetCore.Http;
using FluentValidation;

namespace ListSmarter.webApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;

        }
        [HttpGet]
        public ActionResult<IList<PersonDto>> GetPeople()
        {
            var response = _personService.getAllPeople();

            return Ok(response);
        }
        [HttpPost]
        public ActionResult<PersonDto> CreatePerson([FromBody] CreatePersonDto data)
        {
            PersonDto person = new PersonDto {FirstName = data.FirstName, LastName = data.LastName };
            var result = _personService.addPerson(person);
            var response = new
            {
                message = "Created",
                data = result,
            };
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<PersonDto> GetOnePerson([FromRoute] int id)
        {
            var result = _personService.GetOne(id);

           
            return Ok(result);
        }

        [HttpPut("{id}")]
        public ActionResult<PersonDto> update([FromRoute] int id, [FromBody] PersonDto person)
        {
            var result = _personService.EditPerson(id, person);
            var response = new
            {
                message = "Updated",
                data = result
            };
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePerson([FromRoute] int id)
        {
            try
            {
                _personService.DeletePerson(id);
                var response = new
                {
                    message = "Person Deleted"
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    message = ex.Message
                };
                return StatusCode(500,response);

            }
        }
    }
}
