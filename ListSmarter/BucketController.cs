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
                try
                {
                    _bucketService.CreateBucket(bucket);
                }
                catch (System.Exception E)
                {
                    Console.WriteLine(E.Message);
                    Console.ReadKey();
                }
        }   
        public void DeleteBucket(int id){
            try
            {
                _bucketService.DeleteBucket(id);
            }
            catch (System.Exception E)
            {

                Console.WriteLine(E.Message);
                Console.ReadKey();
            }
        }

         public void UpdateBucket(int id,BucketDto data){
            _bucketService.EditBucket(id,data);
        }

        
    }
}