using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace ListSmarter
{
    public class CreatePersonDto
    {
        public string? FirstName {get;set;}
        public string? LastName {get;set;}

    }
}