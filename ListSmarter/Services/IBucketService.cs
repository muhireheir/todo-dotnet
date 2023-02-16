using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListSmarter.Dtos;

namespace ListSmarter.Services
{
    public interface IBucketService
    {
        List<BucketDto> getAll();
        void CreateBucket(BucketDto bucket);
        void DeleteBucket(int id);
        void EditBucket(int id,BucketDto data);
    }
}