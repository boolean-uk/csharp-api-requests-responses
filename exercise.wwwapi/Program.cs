using exercise.wwwapi.Data;
using exercise.wwwapi.Endpoints;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository<Student>, StudentRepository>();
builder.Services.AddSingleton<IData<Student>, StudentCollection>();
builder.Services.AddScoped<IRepository<Language>, LanguageRepository>();
builder.Services.AddSingleton<IData<Language>, LanguageCollection>();
builder.Services.AddScoped<IBookRepository<Book>, BookRepository>();
builder.Services.AddSingleton<IBookCollection<Book>, BookCollection>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureStudentEndpoint();
app.ConfigureLanguageEnpoint();
app.ConfigureBookEnpoint();

app.Run();

