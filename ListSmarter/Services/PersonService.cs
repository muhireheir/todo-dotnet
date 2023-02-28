using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListSmarter.Repositories;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using ListSmarter.Models;
using ListSmarter.db;
namespace ListSmarter.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository,IValidator<CreatePersonDto> personValidator,ITaskRepository taskRepository,IMapper mapper){
            _personRepository=personRepository;
            _taskRepository=taskRepository;
            _mapper=mapper;
        }

        public List<PersonDto> getAllPeople()
        {
            return _personRepository.GetAll();
        }

        public PersonDto addPerson(PersonDto person){
            _personRepository.Create(person);
            return person;
        }
        public void DeletePerson(int id)
        {
           try
           {
            _personRepository.GetPerson(id);
            
            List<Models.Task> userTasks = _taskRepository.GetPersonTasks(id);
           if(userTasks.Count > 0){
            throw new Exception("Can not delete a person with a task");
           }else{
            _personRepository.Delete(id);
           }
           }
           catch (System.Exception e)
           {
            throw  new Exception(e.Message);
           }
            
        }

        public PersonDto EditPerson(int id, PersonDto data)
        {
             return _personRepository.Update(id,data);

        }

         public PersonDto GetOne(int id){
            Person person = TemporaryDatabase.People.First(p=>p.Id==id);
            return _mapper.Map<PersonDto>(person);
        }

       
    }
}