using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListSmarter.Dtos;
using ListSmarter.Models;

namespace ListSmarter.Repositories
{
    public interface IBucketRepository
    {

        List<BucketDto> GetAll();
        BucketDto Create(BucketDto dto);
        BucketDto Update(int id,BucketDto data);
        void Delete(int id);
        
        Bucket GetOne(int id);
        Bucket GetByTitle(string title);
        
    }
}