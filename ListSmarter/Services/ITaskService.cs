using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListSmarter.Models;
using ListSmarter.Dtos;

namespace ListSmarter.Services
{
    public interface ITaskService
    {
       void AddTask(TaskDto task,int id);
       List<TaskDto> GetTasks();
       void AssignToPerson(int task,int person);
       void AssignToBucket(int taskId, int bucket);
       void ChangeStatus(int task,string status);
    }
}