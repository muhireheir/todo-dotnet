using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ListSmarter.Dtos;
using ListSmarter.Enums;

namespace ListSmarter.validators
{
    public class TaskValidator :AbstractValidator<TaskDto>
    {

        public TaskValidator(){
            RuleFor(task=>task.Bucket).NotEmpty();
            RuleFor(task=>task.Description).NotEmpty();
            RuleFor(task=>task.Title).NotEmpty();
            RuleFor(task=>task.Status).IsInEnum();
        }
        
    }
}