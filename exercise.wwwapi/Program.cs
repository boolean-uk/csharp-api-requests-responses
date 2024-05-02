using exercise.wwwapi.Data;
using exercise.wwwapi.Endpoints;
using exercise.wwwapi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// this object livs throught the entire liftime of the application
builder.Services.AddSingleton<StudentCollection>();

// the IstudentRepository is the interface that needs to be returned.
// And the StudentRepository is the concrete class
// If a method requires this interface it creates a copy/instance of the StudentRepository object for each request.
// that object that is created will only live until a new instance is created / for the duration of that request.
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.ConfigureStudentEndpoints(); 


app.Run();

