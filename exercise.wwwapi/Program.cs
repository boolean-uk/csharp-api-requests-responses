using exercise.wwwapi.Endpoints;
using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Reposity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepository<Student>, StudentRepository>();
builder.Services.AddScoped<IRepository<Language>, LanguageRepository>();
builder.Services.AddScoped<IRepository<Book>, BookRepository>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.ConfigueEndPointStudents();
app.ConfigueEndPointLanguages();
app.ConfigueEndPointBooks();



app.Run();

