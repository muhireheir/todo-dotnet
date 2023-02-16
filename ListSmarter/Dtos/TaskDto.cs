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
        int Id {get;set;}
        string? Title{get;set;}
        string? Description {get;set;}
        TaskEnum Status {get;set;}
        Person? Assignee {get;set;}
        Bucket? Bucket {get;set;}
    }
}