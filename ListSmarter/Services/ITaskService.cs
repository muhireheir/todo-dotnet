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
       void addTask(TaskDto task,int id);
       List<TaskDto> getTasks();
       void AssignToPerson(int task,int person);
    }
}