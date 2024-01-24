using exercise.wwwapi.Models;
using exercise.wwwapi.Endpoints;
using exercise.wwwapi.Repository;
using exercise.wwwapi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// stores this object inside the App / Web Framework
// whenever a request handler needs this object, it will be injected
// this object lives throught the entire lifetime of the application
builder.Services.AddSingleton<StudentCollection>();
builder.Services.AddSingleton<LanguageCollection>();

// this creates a new instance of TaskRepository for each request
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ILanguageRepository, LanguagueRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.ConfigureStudentEndpoints();
 
app.ConfigureLanguageEndpoints();


app.Run();

