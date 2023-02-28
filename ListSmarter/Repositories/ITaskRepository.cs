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
        TaskDto CreateTask(TaskDto task);
        void AssignToPerson(int taskId,int person);
        List<Models.Task>GetPersonTasks(int id);
        List<Models.Task>GetBucketTasks(int id);
        void AssignToBucket(int taskId, int bucket);
        TaskDto UpdateStatus(int task,TaskEnum status);
    }
}

