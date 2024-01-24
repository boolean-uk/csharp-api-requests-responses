using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using exercise.wwwapi.EndPoints;
using exercise.wwwapi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<StudentCollection>();
builder.Services.AddSingleton<LanguageCollection>();

builder.Services.AddSingleton<IStudentRepository, StudentRepository>();
builder.Services.AddSingleton<ILanguageRepository, LanguageRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureStudentEndPoint();

app.ConfigureLanguageEndPoint();



app.Run();

