using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListSmarter.Dtos;
using ListSmarter.Repositories;
using ListSmarter.Models;
using FluentValidation;
using ListSmarter.Enums;
namespace ListSmarter.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IValidator<TaskDto> _taskValidator;
        private IBucketRepository _bucketRepository;
        public TaskService(ITaskRepository taskRepository,IValidator<TaskDto> taskValidator,IBucketRepository bucketRepository){
            _taskRepository=taskRepository;
            _taskValidator=taskValidator;
            _bucketRepository=bucketRepository;
        }

        public void addTask(TaskDto task,int bucketId)
        {

            Bucket bucket = _bucketRepository.GetOne(bucketId);

            Console.WriteLine(bucket.Title);

            if(bucket!=null){
                TaskDto newTask = new TaskDto {Id=task.Id,
                Title=task.Title,
                Description=task.Description,
                Status=TaskEnum.Open,
                Bucket=bucket
                };

            var results = _taskValidator.Validate(newTask);
            if(results.IsValid){
                _taskRepository.CreateTask(newTask);
            }else{
                Console.WriteLine(results);
            }

            }else{
                Console.WriteLine("Invalid bucket Id");
            }            
        }

        public List<TaskDto> getTasks()
        {
            return _taskRepository.GetAll();
        }
    }
}