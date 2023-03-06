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
        public IActionResult GetPeople()
        {
            var response = new
            {
                message = "Ok",
                data = _personService.getAllPeople()
            };

            return new JsonResult(response);

        }
        [HttpPost]
        public ActionResult<PersonDto> CreatePerson([FromBody] CreatePersonDto data)
        {
            Random random = new Random();
            PersonDto person = new PersonDto { Id = random.Next(1, 9999), FirstName = data.FirstName, LastName = data.LastName };
            var result = _personService.addPerson(person);

            var response = new
            {
                message = "Created",
                data = result,
            };
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetOnePerson([FromRoute] int id)
        {
            var result = _personService.GetOne(id);

            var response = new
            {
                message = "Ok",
                data = result
            };
            return new JsonResult(response);
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
            return new JsonResult(response);
        }

        [HttpDelete("/Person/{id}")]
        public IActionResult DeletePerson([FromRoute] int id)
        {
            try
            {
                _personService.DeletePerson(id);
                var response = new
                {
                    message = "Person Deleted"
                };
                return new JsonResult(response);
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
