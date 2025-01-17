using exercise.wwwapi.Endpoints;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using exercise.wwwapi.ViewModel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRepository<Student, Student>, StudentRepository>();
builder.Services.AddScoped<IRepository<Language, Language>, LanguageRepository>();
builder.Services.AddScoped<IRepository<Book, BookViewModel>, BookRepository>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOptions();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureLanguageEndpoint();
app.ConfigureStudentEndpoint();
app.ConfigureBookEndpoint();

app.UseHttpsRedirection();

app.Run();
