using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListSmarter.Models;
using ListSmarter.Dtos;
using AutoMapper;
using ListSmarter.db;

namespace ListSmarter.Repositories
{
    public class BucketRepository : IBucketRepository
    {
        private readonly IMapper _mapper;

       public BucketRepository(IMapper mapper){
            _mapper=mapper;
        }

        public List<BucketDto> GetAll(){
            return _mapper.Map<List<BucketDto>>(TemporaryDatabase.Buckets);
        }

        public BucketDto Create(BucketDto dto)
        {
            Bucket newBucket = _mapper.Map<Bucket>(dto);
            newBucket.Id = TemporaryDatabase.Buckets.Any() ? TemporaryDatabase.Buckets.Max(i => i.Id) + 1 : 1;
            TemporaryDatabase.Buckets.Add(newBucket);
            return dto;
        }

        public BucketDto Update(int id, BucketDto data)
        {
           Bucket bucket = TemporaryDatabase.Buckets.First(bucket=>bucket.Id==id);
           bucket.Title=data.Title;
           return  _mapper.Map<BucketDto>(bucket);
            
        }
        public void Delete(int id)
        {
            Bucket BucketToRemove  = TemporaryDatabase.Buckets.First(bucket=>bucket.Id!=id);
            TemporaryDatabase.Buckets.Remove(BucketToRemove);
        }

        public Bucket GetOne(int id)
        {
            Bucket bucket =  TemporaryDatabase.Buckets.First(bucket=>bucket.Id==id);
            return bucket;
        }

        public Bucket GetByTitle(string title)
        {
            Bucket bucket =  TemporaryDatabase.Buckets.FirstOrDefault(bucket=>bucket.Title==title);
            return bucket;
        }

        
    }
}