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

        public BucketService(IBucketRepository repository){
            _bucketRepository=repository;
        }
        public void CreateBucket(BucketDto bucket)
        {
            _bucketRepository.Create(bucket);
        }

        public void DeleteBucket(int id)
        {
            _bucketRepository.Delete(id);
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