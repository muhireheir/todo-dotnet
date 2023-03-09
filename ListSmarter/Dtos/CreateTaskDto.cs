using System;

namespace ListSmarter.Dtos
{
    public class CreateTaskDto
    {
        public string? Title{get;set;}
        public string? Description {get;set;}
        public int BucketId {get;set;}
    }
}