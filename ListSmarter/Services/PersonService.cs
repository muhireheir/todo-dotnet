using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListSmarter.Repositories;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using ListSmarter.Models;
namespace ListSmarter.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IValidator<PersonDto> _personValidator;
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository,IValidator<PersonDto> personValidator,ITaskRepository taskRepository,IMapper mapper){
            _personRepository=personRepository;
            _personValidator=personValidator;
            _taskRepository=taskRepository;
            _mapper=mapper;
        }

        public List<PersonDto> getAllPeople()
        {
            return _personRepository.GetAll();
        }

        public void addPerson(PersonDto person){
            var validationResults = new List<ValidationResult>();
            var x = _mapper.Map<Person>(person);
            var isValid = Validator.TryValidateObject(x, new ValidationContext(x), validationResults, true);
            if (!isValid)
            {
                throw new Exception("All fields are required");
            }
            _personRepository.Create(person);
        }
        public void DeletePerson(int id)
        {
           List<Models.Task> userTasks = _taskRepository.GetPersonTasks(id);
           if(userTasks.Count > 0){
            throw new Exception("Can not delete a person with a task");
           }else{
            _personRepository.Delete(id);
           }
            
        }

        public void EditPerson(int id, PersonDto data)
        {
             _personRepository.Update(id,data);
        }
    }
}