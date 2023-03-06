using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListSmarter.Dtos;
using ListSmarter.Repositories;
using ListSmarter.Models;
using FluentValidation;
using ListSmarter.Enums;
using AutoMapper;
namespace ListSmarter.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IValidator<TaskDto> _taskValidator;
        private readonly IBucketService _bucketService;
        private readonly IPersonService _personService;
        private IMapper _mapper;
        public TaskService(ITaskRepository taskRepository,IValidator<TaskDto> taskValidator,IBucketService bucketService,IPersonService personService,IMapper mapper){
            _taskRepository=taskRepository;
            _taskValidator=taskValidator;
            _mapper=mapper;
            _bucketService=bucketService;
            _personService=personService;
        }

        public TaskDto AddTask(TaskDto task, int bucketId)
        {
            try
            {
                Bucket bucket = _bucketService.getOne(bucketId);
                TaskDto newTask = new TaskDto
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    Status = TaskEnum.Open,
                    Bucket = _mapper.Map<BucketDto>(bucket)
                };
                return _taskRepository.CreateTask(newTask);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<TaskDto> GetTasks()
        {
            return _taskRepository.GetAll();
        }
        
        public void AssignToPerson(int taskId,int personId){
            Person person =_personService.GetPerson(personId);
            _taskRepository.AssignToPerson(taskId,person);
        }

        public void AssignToBucket(int taskId, int bucketId)
        {
            Bucket bucket = _bucketService.getOne(bucketId);
            _taskRepository.AssignToBucket(taskId,bucket);
        }
        public TaskDto ChangeStatus(int task,TaskEnum status){
    
            return _taskRepository.UpdateStatus(task,status);
        }

        public List<TaskDto> GetBucketTasks(int id){
            return _taskRepository.GetBucketTasks(id);
        }

        public void DeleteTask(int taskId){
            _taskRepository.DeleteTask(taskId);
        }

      public  List<Models.Task> GetPersonTasks(int personId){
        return _taskRepository.GetPersonTasks(personId);
        }
    }
}

