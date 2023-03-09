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
        public ActionResult<IList<TaskDto>> GetAllTask(){
            var response =  new {
                message="SUccess",
                data = _taskService.GetTasks()
            };
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<TaskDto> CreateNewTask([FromBody] CreateTaskDto task){
            try
            {
            TaskDto taskDto = new TaskDto {Title=task.Title,Description=task.Title};
            var createdTask = _taskService.AddTask(taskDto,task.BucketId);
            var response =  new {
                message="Created!",
                data = createdTask
            };
            return StatusCode(201,response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new {message=e.Message});
            }
        }


        [HttpPut("/assignToPerson/{TaskId}/person/{PersonId}")]
        public ActionResult AssignToPerson([FromRoute] int TaskId,[FromRoute] int PersonId){
           try
           {
             _taskService.AssignToPerson(TaskId,PersonId);
            return Ok("Assiged to person");
           }
           catch (Exception e)
           {
            return StatusCode(500, new {message=e.Message});
           }
        }

        [HttpPut("/assignToBucket/{TaskId}/bucket/{BucketId}")]
        public ActionResult AssignToBucket([FromRoute] int TaskId,[FromRoute] int BucketId){
           try
           {
             _taskService.AssignToBucket(TaskId,BucketId);
            return Ok("Assigned to bucket");
           }
           catch (Exception e)
           {
             return StatusCode(500, new {message=e.Message});
           }
        }

        [HttpDelete("{TaskId}")]
        public ActionResult DeleteTask([FromRoute] int TaskId){
           try
           {
             _taskService.DeleteTask(TaskId);
            return Ok("Task Deleted");
           }
           catch (Exception e)
           {
             return StatusCode(500, new {message=e.Message});
           }
        }

        [HttpPut("/changeStatus/{TaskId}")]
        public ActionResult UpdateStatus ([FromRoute] int TaskId,[FromBody] TaskStatusDto status){
               try
               {
                var result  =  _taskService.ChangeStatus(TaskId,status.Status);
                 return Ok(result);
               }
               catch (Exception e)
               {
                 return StatusCode(500, new {message=e.Message});
               }
        }
    }
}