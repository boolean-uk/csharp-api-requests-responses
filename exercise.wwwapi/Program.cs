using exercise.wwwapi.Data;
using exercise.wwwapi.Endpoints;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<StudentCollection>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();


builder.Services.AddSingleton<LanguageCollection>();
builder.Services.AddScoped<IlanguageRepository, LanguageRepository>();

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
app.configureStudentEndpoints();
app.configureLanguageEndpoints();
app.configureBookEndpoints();

app.Run();

