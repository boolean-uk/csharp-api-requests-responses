using exercise.wwwapi.Data;
using exercise.wwwapi.Endpoints;
using exercise.wwwapi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//KK:IMPORTANT
builder.Services.AddScoped<IRepository, Repository>();

builder.Services.AddSingleton<StudentCollection, StudentCollection>();
builder.Services.AddSingleton<LanguageCollection, LanguageCollection>();
builder.Services.AddSingleton<BookCollection, BookCollection>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//KK: IMPORTANT - CALLING OUR EXTENDED METHOD:
app.ConfigureStudentEndpoint();
app.ConfigureLanguageEndpoint();
app.ConfigureBookEndpoint();


app.Run();

