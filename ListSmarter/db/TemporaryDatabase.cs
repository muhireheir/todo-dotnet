using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListSmarter.Models;
using Task = ListSmarter.Models.Task;
using ListSmarter.Enums;
namespace ListSmarter.db
{
    public static class TemporaryDatabase
    {

        public static List<Bucket> Buckets = new List<Bucket>{
            new Bucket{Id=1,Title="Home Task"},
            new Bucket{Id=2,Title="School Task"}
        };

        public static List<Person> People = new List<Person>{
            new Person {Id=1,FirstName="Heritier",LastName="UMUHIRE"},
            new Person {Id=2,FirstName="Lenny",LastName="Pascal"},
        };

        public static List<Task> Tasks = new List<Task>{
            new Task{Id=1,Title="Finish homework",Status=TaskEnum.Open},
            new Task{Id=2,Title="Do laundry",Status=TaskEnum.InProgress}
        };
        
    }
}