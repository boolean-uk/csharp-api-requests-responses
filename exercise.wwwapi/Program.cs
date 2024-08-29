using exercise.wwwapi.Endpoints;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IRepository<Student>, GenericRepository<Student>>();
builder.Services.AddTransient<IRepository<Book>, GenericRepository<Book>>();
builder.Services.AddTransient<IRepository<Language>, GenericRepository<Language>>();
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
app.ConfigureBookEndpoints();

app.Run();

