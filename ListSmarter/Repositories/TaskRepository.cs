using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListSmarter.Dtos;
using ListSmarter.Models;
using ListSmarter.Enums;
using AutoMapper;
using ListSmarter.db;

namespace ListSmarter.Repositories
{
    public class TaskRepository : ITaskRepository
    {



        private readonly IMapper _mapper;

        public TaskRepository(IMapper mapper,IPersonRepository personRepository,IBucketRepository bucketRepository){
            _mapper = mapper;
        }


        public TaskDto CreateTask(TaskDto task)
        {
            Models.Task newTask = _mapper.Map<Models.Task>(task);
            newTask.Id = TemporaryDatabase.Tasks.Any() ? TemporaryDatabase.Tasks.Max(i => i.Id) + 1 : 1;
            TemporaryDatabase.Tasks.Add(newTask);
            task.Id=newTask.Id;
            return task;
        }

        public List<TaskDto> GetAll()
        {
           return  _mapper.Map<List<TaskDto>>(TemporaryDatabase.Tasks);
        }
        public void AssignToPerson(int taskId, Person person)
        {
            Models.Task task = TemporaryDatabase.Tasks.First(task=>task.Id==taskId);
            task.Assignee=person;
        }


         public void AssignToBucket(int taskId, Bucket bucket)
        {
            Models.Task task = TemporaryDatabase.Tasks.First(task=>task.Id==taskId);
            task.Bucket=bucket;
        }

       public  List<Models.Task> GetPersonTasks(int id)
        {
            return TemporaryDatabase.Tasks.Where(task=>task.Assignee?.Id==id).ToList();
        }

        public List<TaskDto> GetBucketTasks(int id)
        {
            var tasks = TemporaryDatabase.Tasks.Where(task=>task.Bucket?.Id==id).ToList();
            return _mapper.Map<List<TaskDto>>(tasks);
        }

        public TaskDto UpdateStatus(int taskId ,TaskEnum status){
            Models.Task task = TemporaryDatabase.Tasks.First(task=>task.Id==taskId);
            task.Status=status;
            return _mapper.Map<TaskDto>(task);
        }

        public void DeleteTask(int TaskId){
            Models.Task task = TemporaryDatabase.Tasks.First(task=>task.Id==TaskId);
            TemporaryDatabase.Tasks.Remove(task);
        }

        
    }
}
