using exercise.wwwapi.Data;
using exercise.wwwapi.EndPoints;
using exercise.wwwapi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<StudentCollection>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddSingleton<LanguageCollection>();
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.StudentEndPointConfig();
app.LanguageEndPointConfig();

app.Run();

