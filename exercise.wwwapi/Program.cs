using exercise.wwwapi.Data;
using exercise.wwwapi.Endpoints.cs;
using exercise.wwwapi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Register the data collection
builder.Services.AddSingleton<DataCollection>();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//Asking for interface, return instance, /
builder.Services.AddScoped<IRepository, Repository>();
var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//Endpoint for student
app.ConfigureStudentsEndpoint();

// Endpoint for languages
app.ConfigureLanguageEndpoint();

//Endpoint for Book
app.ConfigureBookEndpoint();



app.Run();

