using exercise.wwwapi.Data;
using exercise.wwwapi.Endpoints;
using exercise.wwwapi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddSingleton<IStudentData, StudentCollection>();

builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
builder.Services.AddSingleton<ILanguageData, LanguageCollection>();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddSingleton<IBookData, BookCollection>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureStudentEndPoints();
app.ConfigureLanguageEndPoints();
app.ConfigureBookEndPoints();

app.Run();

