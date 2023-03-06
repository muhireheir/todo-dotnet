using Microsoft.AspNetCore.Mvc;
using ListSmarter.Services;
using ListSmarter.Dtos;
using Microsoft.AspNetCore.Http;
using FluentValidation;

namespace ListSmarter.webApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BucketController : ControllerBase
    {
        private readonly IBucketService _bucketService;
        private readonly ITaskService _taskService;
        public BucketController(IBucketService bucketService,ITaskService taskService)
        {
            _bucketService = bucketService;
            _taskService=taskService;
        }

        [HttpGet]
        public ActionResult<List<BucketDto>> GetBuckets()
        {
            try
            {
                IEnumerable<BucketDto> buckets = _bucketService.getAll();
                return Ok(buckets);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    message = ex.Message
                };
                return StatusCode(500, response);
            }
        }
        [HttpPost]
        public ActionResult CreateBucket([FromBody] BucketDto bucket)
        {
            try
            {
                var data = new
                {
                    message = "Created",
                    data = _bucketService.CreateBucket(bucket)
                };
                return StatusCode(201, data);


            }
            catch (System.Exception ex)
            {

                var response = new
                {
                    message = ex.Message
                };
                return StatusCode(500, response);
            }
        }

        [HttpGet("/Bucket/{id}")]
        public ActionResult GetBucket([FromRoute] int id)
        {
            try
            {

                var response = new
                {
                    message = "Success",
                    data = _bucketService.getOne(id)
                };
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message
                });
            }
        }

        [HttpDelete("/Bucket/{id}")]
        public IActionResult DeleteBucket([FromRoute] int id)
        {
            try
            {
                _bucketService.DeleteBucket(id);
                var response = new
                {
                    message = "Success"
                };
                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message
                });
            }
        }


        [HttpPut("/Bucket/{id}")]
        public IActionResult UpdateBucket([FromRoute] int id, [FromBody] BucketDto data)
        {
            try
            {
                BucketDto response = _bucketService.EditBucket(id, data);
                return StatusCode(200, new
                {
                    message = "Success",
                    data = response
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message
                });
            }
        }


        [HttpGet("/Bucket/{id}/Tasks")]
        public IActionResult GetTasks([FromRoute] int id){
            try
            {
                IEnumerable<TaskDto> tasks = _taskService.GetBucketTasks(id);
                return StatusCode(200,new {message="SUccess",data=tasks});
            }
            catch (Exception ex)
            {
                
                 return StatusCode(500, new
                {
                    message = ex.Message
                });
            }
        }

    }
}
