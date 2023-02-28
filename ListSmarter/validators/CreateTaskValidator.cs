using System;
using FluentValidation;
using ListSmarter.Dtos;

namespace ListSmarter.validators
{
    public class CreateTaskValidator :AbstractValidator<CreateTaskDto>
    {
         public CreateTaskValidator(){
            RuleFor(task=>task.Description).NotEmpty();
            RuleFor(task=>task.Title).NotEmpty();
            RuleFor(task=>task.BucketId).NotEmpty().NotNull().NotEqual(0);
        }
    }
}

