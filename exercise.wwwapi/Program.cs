using exercise.wwwapi.Data;
using exercise.wwwapi.Endpoints;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Repositories
builder.Services.AddScoped<IRepository<Student>, Repository<Student>>();
builder.Services.AddScoped<IRepository<Language>, Repository<Language>>();
builder.Services.AddScoped<IRepository<Book>, Repository<Book>>();

// Add In-Memory Databases
builder.Services.AddSingleton<IDatabase<Student>, StudentCollection>();
builder.Services.AddSingleton<IDatabase<Language>, LanguageCollection>();
builder.Services.AddSingleton<IDatabase<Book>, BookCollection>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureStudentEndpoint();
app.ConfigureLanguageEndpoint();
app.ConfigureBookEndpoint();

app.Run();

