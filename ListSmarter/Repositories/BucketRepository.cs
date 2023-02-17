using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListSmarter.Models;
using ListSmarter.Dtos;
using AutoMapper;

namespace ListSmarter.Repositories
{
    public class BucketRepository : IBucketRepository
    {
        private readonly IMapper _mapper;

       public BucketRepository(IMapper mapper){
            _mapper=mapper;
        }
        List<Bucket> Buckets = new List<Bucket>{
            new Bucket{Id=1,Title="Home Task"},
            new Bucket{Id=2,Title="School Task"}
        };
        
        public List<BucketDto> GetAll(){
            return _mapper.Map<List<BucketDto>>(Buckets);
        }

        public void Create(BucketDto dto)
        {
            Bucket newBucket = _mapper.Map<Bucket>(dto);
            Buckets.Add(newBucket);
        }

        public void Update(int id, BucketDto data)
        {
           Bucket bucket = Buckets.First(bucket=>bucket.Id==id);
           bucket.Title=data.Title;
            
        }
        public void Delete(int id)
        {
            List<Bucket> buckets  = Buckets.Where(bucket=>bucket.Id!=id).ToList();
            Buckets.Clear();
            Buckets.AddRange(buckets);
        }

        public Bucket GetOne(int id)
        {
            Bucket bucket =  Buckets.Where(bucket=>bucket.Id==id).FirstOrDefault();
            return bucket;
        }
    }
}