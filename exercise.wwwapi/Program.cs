using System.Diagnostics.Metrics;
using System.Threading.Tasks;
using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Endpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using exercise.wwwapi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<LanguageCollection>();
builder.Services.AddSingleton<StudentCollection>();
builder.Services.AddSingleton<BookCollection>();
builder.Services.AddSingleton<BooksRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


var studentGroup = app.MapGroup("students");

studentGroup.MapPost("/CreateStudent/{firstName}/{lastName}", StudentEndpoints.CreateStudent);
studentGroup.MapGet("/", StudentEndpoints.GetAllStudents);
studentGroup.MapGet("/UpdatedStudent/{firstName}", StudentEndpoints.GetAStudent);
studentGroup.MapPut("/UpdatedStudent/{firstName}/{lastName}", StudentEndpoints.UpdateAStudent);
studentGroup.MapDelete("/DeletedStudent/{firstName}", StudentEndpoints.DeleteStudent);


var LanguageGroup = app.MapGroup("languages");

LanguageGroup.MapPost("/CreateLanguage/{language}", LanguageEndpoints.CreateLanguage);
LanguageGroup.MapGet("/", LanguageEndpoints.GetAllLanguages);
LanguageGroup.MapGet("/{language}", LanguageEndpoints.GetALanguage);
LanguageGroup.MapPut("/UpdatedLanguage/{NewName}", LanguageEndpoints.UpdateALanguage);
LanguageGroup.MapDelete("/{language}", LanguageEndpoints.DeleteLanguage);


var BooksGroup = app.MapGroup("books");

BooksGroup.MapPost("/CreateBook/{newBook}", BooksEndpoints.CreateBook);
BooksGroup.MapGet("/", BooksEndpoints.GetAllBooks);
BooksGroup.MapGet("/{id}", BooksEndpoints.GetASingleBook);
BooksGroup.MapPut("/UpdatedBook/{book}", BooksEndpoints.UpdateBook);
BooksGroup.MapDelete("/´DeletedBook/{book}", BooksEndpoints.DeleteBook);


app.Run();

