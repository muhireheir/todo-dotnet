using Microsoft.AspNetCore.Mvc;
using ListSmarter.Services;
using ListSmarter.Dtos;
using Microsoft.AspNetCore.Http;
using FluentValidation;



namespace ListSmarter.webApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {

        private readonly ITaskService _taskService;
        private readonly IBucketService _bucketService;
        public TaskController(ITaskService taskService,IBucketService bucketService){
            _taskService=taskService;
            _bucketService=bucketService;
        }

        [HttpGet(Name="Get All tasks")]
        public IActionResult GetAllTask(){
            var response =  new {
                message="SUccess",
                data = _taskService.GetTasks()
            };
            return StatusCode(200,response);
        }

        [HttpPost]
        public IActionResult CreateNewTask([FromBody] CreateTaskDto task){
            try
            {
            Random randomInt = new Random();
            int id = randomInt.Next(1,99999);
            TaskDto taskDto = new TaskDto {Id=id,Title=task.Title,Description=task.Title};
            var createdTask = _taskService.AddTask(taskDto,task.BucketId);
            var response =  new {
                message="Created!",
                data = createdTask
            };
            return StatusCode(2001,response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new {message=e.Message});
            }
        }


        [HttpPut("/assignToPerson/{TaskId}/person/{PersonId}")]
        public IActionResult AssignToPerson([FromRoute] int TaskId,[FromRoute] int PersonId){
           try
           {
             _taskService.AssignToPerson(TaskId,PersonId);
            return StatusCode(200, new {message="Assiged"});
           }
           catch (Exception e)
           {
            return StatusCode(500, new {message=e.Message});
           }
        }

        [HttpPut("/assignToBucket/{TaskId}/bucket/{BucketId}")]
        public IActionResult AssignToBucket([FromRoute] int TaskId,[FromRoute] int BucketId){
           try
           {
             _taskService.AssignToBucket(TaskId,BucketId);
            return StatusCode(200, new {message="Assiged"});
           }
           catch (Exception e)
           {
             return StatusCode(500, new {message=e.Message});
           }
        }

        [HttpDelete("{TaskId}")]
        public IActionResult DeleteTask([FromRoute] int TaskId){
           try
           {
             _taskService.DeleteTask(TaskId);
            return StatusCode(200, new {message="Task Deleted"});
           }
           catch (Exception e)
           {
             return StatusCode(500, new {message=e.Message});
           }
        }

        [HttpPut("/changeStataus/{TaskId}")]
        public IActionResult UpdateStatus ([FromRoute] int TaskId,[FromBody] TaskStatusDto status){
               try
               {
                var result  =  _taskService.ChangeStatus(TaskId,status.Status);
                 return StatusCode(200, new {message="Status Updated",data=result});
               }
               catch (Exception e)
               {
                 return StatusCode(500, new {message=e.Message});
               }
        }
    }
}