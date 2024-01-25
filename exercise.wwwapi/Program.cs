using exercise.wwwapi.Data;
using exercise.wwwapi.Endpoints;
using exercise.wwwapi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddSingleton<ILanguageDB, LanguageCollection>();
builder.Services.AddSingleton<IStudentDB, StudentCollection>();
builder.Services.AddSingleton<IBookDB, BookCollection>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.ConfigureLanguageEndpoint();
app.ConfigureStudentEndpoint();
app.ConfigureBookEndpoint();


app.Run();

