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
        private IBucketRepository _bucketRepository;
        private IPersonRepository _personRepository;
        private IMapper _mapper;
        public TaskService(ITaskRepository taskRepository,IValidator<TaskDto> taskValidator,IBucketRepository bucketRepository,IPersonRepository personRepository,IMapper mapper){
            _taskRepository=taskRepository;
            _taskValidator=taskValidator;
            _bucketRepository=bucketRepository;
            _personRepository=personRepository;
            _mapper=mapper;
        }

        public TaskDto AddTask(TaskDto task, int bucketId)
        {
            try
            {
                Bucket bucket = _bucketRepository.GetOne(bucketId);
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
            Person person =_personRepository.GetPerson(personId);
            _taskRepository.AssignToPerson(taskId,personId);
        }

        public void AssignToBucket(int taskId, int bucketId)
        {
            _taskRepository.AssignToBucket(taskId,bucketId);
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
    }
}

