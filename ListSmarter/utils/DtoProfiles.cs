using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ListSmarter.Models;
namespace ListSmarter
{
    public class DtoProfiles :Profile
    {

        public DtoProfiles(){
            CreateMap<Person,PersonDto>();
        }
        
    }
}