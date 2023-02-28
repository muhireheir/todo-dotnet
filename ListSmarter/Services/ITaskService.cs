using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListSmarter.Models;
using ListSmarter.Dtos;
using ListSmarter.Enums;

namespace ListSmarter.Services
{
    public interface ITaskService
    {
       TaskDto AddTask(TaskDto task,int bucketId);
       List<TaskDto> GetTasks();
       void AssignToPerson(int task,int person);
       void AssignToBucket(int taskId, int bucket);
       TaskDto ChangeStatus(int task,TaskEnum status);
       List<TaskDto>GetBucketTasks(int id);
       void DeleteTask(int taskId);

    }
}