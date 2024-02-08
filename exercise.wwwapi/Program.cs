using exercise.wwwapi.Data;
using exercise.wwwapi.Endpoints;
using exercise.wwwapi.Models.Book;
using exercise.wwwapi.Models.Language;
using exercise.wwwapi.Models.Student;
using exercise.wwwapi.Repository;
using exercise.wwwapi.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<StudentCollection>();
builder.Services.AddSingleton<LanguageCollection>();
builder.Services.AddSingleton<BookCollection>();



builder.Services.AddScoped<IStudentRepo, StudentRepository>();
builder.Services.AddScoped<IRepository<Student>, StudentRepository>();

builder.Services.AddScoped<ILanguageRepo, LanguageRepository>();
builder.Services.AddScoped<IRepository<Language>, LanguageRepository>();

builder.Services.AddScoped<IRepository<Book>, BookRepository>();
builder.Services.AddScoped<IBookRepo, BookRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//StudentEndpoints.ConfigureStudentEndpoints(app);
//LanguageEndpoints.ConfigureLanguageEndPoints(app);
StudentEndpoints.ConfigureStudentEndpoints(app);
LanguageEndpoints.ConfigureLanguageEndPoints(app);
BookEndpoints.ConfigureBookEndPoints(app);



app.Run();

