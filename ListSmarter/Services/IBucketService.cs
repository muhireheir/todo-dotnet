using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListSmarter.Dtos;
using ListSmarter.Models;

namespace ListSmarter.Services
{
    public interface IBucketService
    {
        List<BucketDto> getAll();
        BucketDto CreateBucket(BucketDto bucket);
        void DeleteBucket(int id);
        BucketDto EditBucket(int id,BucketDto data);
        Bucket getOne(int id);
    }
}