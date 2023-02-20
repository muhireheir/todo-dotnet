using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListSmarter.Dtos;
using ListSmarter.Models;
using ListSmarter.Enums;
namespace ListSmarter.Repositories
{
    public interface ITaskRepository
    {
        List<TaskDto>GetAll();
        void CreateTask(TaskDto task);
        void AssignToPerson(int taskId,Person person);
        List<Models.Task>GetPersonTasks(int id);
        List<Models.Task>GetBucketTasks(int id);
         void AssignToBucket(int taskId, Bucket bucket);
         void updateStatus(int task,TaskEnum status);
    }
}

