using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListSmarter.Services;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using ListSmarter.Repositories;
using FluentValidation;
using ListSmarter.validators;
using ListSmarter.Dtos;

namespace ListSmarter
{
    public static class IoCExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IPersonService, PersonService>();
            services.AddSingleton<IBucketService, BucketService>();
            services.AddSingleton<ITaskService, TaskService>();
            services.AddAutoMapper(typeof(DtoProfiles));
        }

        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddSingleton<IPersonRepository, PersonRepository>();
            services.AddSingleton<IBucketRepository, BucketRepository>();
            services.AddSingleton<ITaskRepository, TaskRepository>();
        }

        public static void RegisterValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<PersonDto>, PersonValidator>();
            services.AddTransient<IValidator<TaskDto>, TaskValidator>();
        }
    }
}
