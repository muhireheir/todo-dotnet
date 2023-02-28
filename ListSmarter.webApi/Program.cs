using ListSmarter;
using FluentValidation.AspNetCore;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.RegisterServices();
builder.Services.RegisterRepository();
builder.Services.RegisterValidators();

builder.Services.AddControllers().AddFluentValidation();
builder.Services.Configure<ApiBehaviorOptions>(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var errorMessages = context.ModelState
                .Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage);

            var errorResponse = new
            {
                Message = "The request was invalid.",
                Errors = errorMessages
            };

            return new BadRequestObjectResult(errorResponse);
        };
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
