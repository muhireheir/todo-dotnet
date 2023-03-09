using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ListSmarter.Dtos;
using ListSmarter.Enums;

namespace ListSmarter.validators
{
    public class TaskStatusEditValidator :AbstractValidator<TaskStatusDto>
    {

        public TaskStatusEditValidator(){
            RuleFor(task=>task.Status).IsInEnum();
        }
        
    }
}