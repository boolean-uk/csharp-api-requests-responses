using exercise.wwwapi.Data;
using exercise.wwwapi.EndPoints;
using exercise.wwwapi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<StudentCollection>();
builder.Services.AddScoped<IRepository<Student>, StudentRepository>();

builder.Services.AddSingleton<LanguageCollection>();
builder.Services.AddScoped<IRepository<Language>, LanguageRepository >();

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


app.ConfigureStudentEndpoints();
app.ConfigureLanguageEndpoints();
app.ConfigureBookEndpoints();


app.Run();

