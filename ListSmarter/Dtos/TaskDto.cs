using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListSmarter.Models;
using ListSmarter.Enums;


namespace ListSmarter.Dtos
{
    public class TaskDto
    {
        public int Id {get;set;}
        public string? Title{get;set;}
        public string? Description {get;set;}
        public TaskEnum Status {get;set;}
        public PersonDto? Assignee {get;set;}
        public BucketDto? Bucket {get;set;}
    }
}