using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<StudentCollection>();
builder.Services.AddScoped<IStudentRepositiry, StudentRepository>();
builder.Services.AddSingleton<LanguageCollection>();
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var studentGroup = app.MapGroup("/studens");
var languageGroup = app.MapGroup("/language");


studentGroup.MapGet("/", (IStudentRepositiry student) => {
    return TypedResults.Ok(student.GetAllStudents());
});

studentGroup.MapPost("/", (IStudentRepositiry student, StudentPostPayload payload) =>
{
    Student newStudent = student.AddStudent(payload);
    return TypedResults.Created($"/student: ", newStudent);
});

studentGroup.MapPut("/{firstname}", (string firstname, IStudentRepositiry student, StudentPutPayload payload) => {
    Student updateStudent = student.UpdateStudent(firstname, payload);
    return TypedResults.Created($"/student/{firstname}", updateStudent);
});

studentGroup.MapDelete("/{firstname}", (string firstname, IStudentRepositiry student) =>
{
    student.DeleteStudent(firstname);
    return TypedResults.NoContent();
    
    
});

languageGroup.MapGet("/", (ILanguageRepository language) =>
{
    return TypedResults.Ok(language.getAllLanguages());
});


app.Run();

