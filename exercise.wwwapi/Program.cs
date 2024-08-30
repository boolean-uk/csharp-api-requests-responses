using exercise.wwwapi.Endpoints;
using exercise.wwwapi.Interfaces;
using exercise.wwwapi.Models;
using exercise.wwwapi.Reposetories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository<Student, string>, StudentRepo>();
builder.Services.AddScoped<IRepository<Language, string>, LanguageRepo>();
builder.Services.AddScoped<IRepository<Book, int>, BookRepo>();
//builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("BookDb"));

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

