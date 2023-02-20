using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListSmarter.Dtos;
using ListSmarter.Repositories;
using ListSmarter.Models;
namespace ListSmarter.Services
{
    public class BucketService : IBucketService
    {

        public IBucketRepository _bucketRepository;
        public ITaskRepository _taskRepository;

        public BucketService(IBucketRepository repository,ITaskRepository taskRepository){
            _bucketRepository=repository;
            _taskRepository=taskRepository;
        }
        public void CreateBucket(BucketDto bucket)
        {
            List<BucketDto> buckets = _bucketRepository.GetAll();
            if(buckets.Count>=10){
                throw new Exception("Opps! the bucket is Full");
            }
            _bucketRepository.Create(bucket);
        }

        public void DeleteBucket(int id)
        {
            List<Models.Task> taskCount = _taskRepository.GetBucketTasks(id); 
            if(taskCount.Count>0){
                throw new Exception("Only empty buckets can be deleted");
            }else{
                _bucketRepository.Delete(id);
            }
            
        }

        public void EditBucket(int id, BucketDto data)
        {
            _bucketRepository.Update(id,data);
        }

        public List<BucketDto> getAll()
        {
            return _bucketRepository.GetAll();
        }

        public Bucket getOne(int id)
        {
           return  _bucketRepository.GetOne(id);
        }

       
    }
}