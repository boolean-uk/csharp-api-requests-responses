using exercise.wwwapi.Endpoints;
using exercise.wwwapi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepository, StudentRepository>();
builder.Services.AddScoped<ILanguage, LanguageRepository>();
builder.Services.AddScoped<IBook, BookRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.ConfigureStudentsEndpoint();
app.ConfigureLanguageEndpoint();
app.ConfigureBooksEndpoint();


app.Run();

