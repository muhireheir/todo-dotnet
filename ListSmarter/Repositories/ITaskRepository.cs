using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListSmarter.Dtos;
namespace ListSmarter.Repositories
{
    public interface ITaskRepository
    {
        List<TaskDto>GetAll();
        void CreateTask(TaskDto task);
    }
}

