using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListSmarter.Services;
using ListSmarter.Dtos;
using ListSmarter.Models;
using ListSmarter.Enums;
using AutoMapper;



namespace ListSmarter
{
    public class TaskController
    {   
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService){
                _taskService=taskService;
        }


        public List<TaskDto>GetAllTasks(){
            return _taskService.GetTasks();
        }

        public void createNewTask(TaskDto task,int bucketId){
            _taskService.AddTask(task,bucketId);
        }
        
        public void AssignToPerson(int task,int person){
            _taskService.AssignToPerson(task,person);
        }

        public void AssignToBucket(int task,int bucket){
            _taskService.AssignToBucket(task,bucket);
        }

        //  public void ChangeStatus(int task,string status){
        //     _taskService.ChangeStatus(task,status);
        //  }

    }
}