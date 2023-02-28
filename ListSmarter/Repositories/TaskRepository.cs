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
        private readonly IPersonRepository _personRepository;
        private readonly IBucketRepository _bucketRepository;
        public TaskRepository(IMapper mapper,IPersonRepository personRepository,IBucketRepository bucketRepository){
            _mapper = mapper;
            _personRepository=personRepository;
            _bucketRepository = bucketRepository;
        }


        public TaskDto CreateTask(TaskDto task)
        {
            Models.Task newTask = _mapper.Map<Models.Task>(task);
            TemporaryDatabase.Tasks.Add(newTask);
            return task;
        }

        public List<TaskDto> GetAll()
        {
           return  _mapper.Map<List<TaskDto>>(TemporaryDatabase.Tasks);
        }
        public void AssignToPerson(int taskId, int personId)
        {
            Models.Task task = TemporaryDatabase.Tasks.First(task=>task.Id==taskId);
            Person person =  _personRepository.GetPerson(personId);
            task.Assignee=person;
        }


         public void AssignToBucket(int taskId, int bucketId)
        {
            Models.Task task = TemporaryDatabase.Tasks.First(task=>task.Id==taskId);
           Bucket bucket= _bucketRepository.GetOne(bucketId);
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
