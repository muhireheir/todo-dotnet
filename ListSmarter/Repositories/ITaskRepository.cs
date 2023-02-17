using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListSmarter.Dtos;
using ListSmarter.Models;
namespace ListSmarter.Repositories
{
    public interface ITaskRepository
    {
        List<TaskDto>GetAll();
        void CreateTask(TaskDto task);
        void AssignToPerson(int taskId,Person person);
    }
}

