using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListSmarter.Dtos;
using ListSmarter.Models;
using ListSmarter.Enums;
using AutoMapper;

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

        List<Models.Task> Tasks = new List<Models.Task>{
            new Models.Task{Id=1,
            Title="First Task",
            Description="Descrption",
            Status=TaskEnum.Open
            }
        };
        public void CreateTask(TaskDto task)
        {
            Models.Task newTask = _mapper.Map<Models.Task>(task);
            Tasks.Add(newTask);
        }

        public List<TaskDto> GetAll()
        {
           return  _mapper.Map<List<TaskDto>>(Tasks);
        }
        public void AssignToPerson(int taskId, Person person)
        {
            Models.Task task = Tasks.First(task=>task.Id==taskId);
            task.Assignee=person;
        }


         public void AssignToBucket(int taskId, Bucket bucket)
        {
            Models.Task task = Tasks.First(task=>task.Id==taskId);
            task.Bucket=bucket;
        }

       public  List<Models.Task> GetPersonTasks(int id)
        {
            return Tasks.Where(task=>task.Assignee?.Id==id).ToList();
        }

        public List<Models.Task> GetBucketTasks(int id)
        {
            return Tasks.Where(task=>task.Bucket?.Id==id).ToList();
        }

        public void updateStatus(int taskId ,TaskEnum status){
            Models.Task task = Tasks.First(task=>task.Id==taskId);
            task.Status=status;
        }

        


    }
}
