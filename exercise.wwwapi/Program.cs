using exercise.wwwapi.Core.Data;
using exercise.wwwapi.Core.Endpoints;
using exercise.wwwapi.Core.Repositories;
using exercise.wwwapi.Extension.Books.Data;
using exercise.wwwapi.Extension.Books.Endpoint;
using exercise.wwwapi.Extension.Books.Repository;
using exercise.wwwapi.Extension.Books.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();


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
StudentCollection.Initialize();
LanguageCollection.Initialize();
BookCollection.Initialize();

app.Run();

