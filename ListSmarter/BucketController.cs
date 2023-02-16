using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListSmarter.Services;
using ListSmarter.Dtos;

namespace ListSmarter
{
    public class BucketController
    {
        IBucketService _bucketService;
        public BucketController(IBucketService bucketService){
            _bucketService = bucketService;
        }


        public List<BucketDto>GetBuckets(){
            return _bucketService.getAll();
        }

        public void CreateBucket(BucketDto bucket){
                _bucketService.CreateBucket(bucket);
        }   
        public void DeleteBucket(int id){
            _bucketService.DeleteBucket(id);
        }

         public void UpdateBucket(int id,BucketDto data){
            _bucketService.EditBucket(id,data);
        }

        
    }
}