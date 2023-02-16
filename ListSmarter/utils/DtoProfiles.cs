using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ListSmarter.Models;
using ListSmarter.Dtos;
namespace ListSmarter
{
    public class DtoProfiles :Profile
    {

        public DtoProfiles(){
            CreateMap<Person,PersonDto>();
            CreateMap<PersonDto,Person>();
            CreateMap<BucketDto,Bucket>();
            CreateMap<Bucket,BucketDto>();
        }
        
    }
}