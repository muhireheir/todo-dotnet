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
                List<BucketDto> buckets = _bucketService.getAll();
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
        public ActionResult<BucketDto> CreateBucket([FromBody] BucketDto bucket)
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

        [HttpGet("{id}")]
        public ActionResult<BucketDto> GetBucket([FromRoute] int id)
        {
            try
            {

                var response = _bucketService.getOne(id);
                
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBucket([FromRoute] int id)
        {
            try
            {
                _bucketService.DeleteBucket(id);
                return Ok("Deleted !");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message
                });
            }
        }


        [HttpPut("{id}")]
        public ActionResult<BucketDto> UpdateBucket([FromRoute] int id, [FromBody] BucketDto data)
        {
            try
            {
                BucketDto response = _bucketService.EditBucket(id, data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message
                });
            }
        }


        [HttpGet("{id}/Tasks")]
        public ActionResult<IList<TaskDto>> GetTasks([FromRoute] int id){
            try
            {
                IList<TaskDto> tasks = _taskService.GetBucketTasks(id);
                return Ok(tasks);
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
