using exercise.wwwapi.Data;
using exercise.wwwapi.Models.Language;
using exercise.wwwapi.Models.Student;
using exercise.wwwapi.Models.Book;
using exercise.wwwapi.Repository.BookRepositories;
using exercise.wwwapi.Repository.LanguageRepositories;
using exercise.wwwapi.Repository.StudentRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Cryptography;
using exercise.wwwapi.EndPoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// student
builder.Services.AddSingleton<StudentCollection>();
builder.Services.AddScoped<IStudentRepositiry, StudentRepository>();
// language
builder.Services.AddSingleton<LanguageCollection>();
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
// book extension
builder.Services.AddSingleton<BookCollection>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

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
var bookGroup = app.MapGroup("/books");

app.ConfigureBookEndpoints();

studentGroup.MapGet("/", (IStudentRepositiry student) => {
    return TypedResults.Ok(student.GetAllStudents());
});

studentGroup.MapPost("/", (IStudentRepositiry student, StudentPostPayload payload) =>
{
    Student newStudent = student.AddStudent(payload);
    return TypedResults.Created($"/student: ", newStudent);
});

studentGroup.MapGet("/{firstname}", (string firstname, IStudentRepositiry student) =>
{
    Student foundStudent = student.GetStudent(firstname);
    return TypedResults.Ok(foundStudent);
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

languageGroup.MapPost("/", (ILanguageRepository language, LanguagePostPayload payload) =>
{
    Language newLanguage = language.AddLanguage(payload);
    return TypedResults.Created($"/language: ", newLanguage);
});

languageGroup.MapGet("/{name}", (string name, ILanguageRepository language) =>
{
    Language foundLanguage = language.GetLanguageByName(name);
    return TypedResults.Ok(foundLanguage);
});

languageGroup.MapPut("/{name}", (string name, ILanguageRepository language, LanguagePutPayload payload) =>
{
    Language updateLanguage = language.UpdateLanguage(name, payload);
    return TypedResults.Created($"/languages({name}: ", updateLanguage);
});

languageGroup.MapDelete("/{name}", (string name, ILanguageRepository language) =>
{
    language.deleteLanguage(name);
    return TypedResults.NoContent();
});


/*
//! BOOKS
bookGroup.MapGet("/", (IBookRepository book) =>
{
    return TypedResults.Ok(book.getAllBooks());
});

bookGroup.MapGet("/{_id}", (int _id, IBookRepository book) =>
{
    Book foundBook = book.getBookById(_id); 
    return TypedResults.Ok(foundBook);
});

bookGroup.MapPost("/", (IBookRepository book, BookPostPayload payload) =>
{
    Book createdBook = book.AddBook(payload);
    return TypedResults.Created($"/books: ",createdBook);
});

bookGroup.MapPut("/{_id}", (int _id, IBookRepository book, BookPutPayload payload) =>
{
    Book updatedBook = book.UpdateBook(_id, payload);
    return TypedResults.Created($"/books/{_id} ", updatedBook);
});

bookGroup.MapDelete("/{_id}", (int _id, IBookRepository book) =>
{
    book.DeleteBook(_id);
    return TypedResults.Ok();
});*/

app.Run();

