using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListSmarter.Services;

namespace ListSmarter
{
    public class TaskController
    {   
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService){
                _taskService=taskService;
        }
    }
}