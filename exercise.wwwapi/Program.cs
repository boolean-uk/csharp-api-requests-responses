using exercise.wwwapi.Data;
using exercise.wwwapi.Endpoints;
using exercise.wwwapi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<StudentCollection>();
builder.Services.AddSingleton<LanguageCollection>();
builder.Services.AddSingleton<BookCollection>();
builder.Services.AddScoped<BookRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//Students
app.MapGet("/students", StudentEndpoints.GetAllStudents);
app.MapGet("/students{name}", StudentEndpoints.GetStudent);
app.MapPost("/students", StudentEndpoints.AddStudent);
app.MapPut("/students{name}", StudentEndpoints.UpdateStudent);
app.MapDelete("/students{name}", StudentEndpoints.DeleteStudent);

//Languages
app.MapPost("/languages", LanguageEndpoints.AddLanguage);
app.MapGet("/languages", LanguageEndpoints.GetAllLanguages);
app.MapGet("/languages{name}", LanguageEndpoints.GetLanguage);
app.MapPut("/languages{name}", LanguageEndpoints.UpdateLanguage);
app.MapDelete("/languages{name}", LanguageEndpoints.DeleteLanguage);

//Books
app.MapPost("/books", BookEndpoints.AddBook);
app.MapGet("/books",BookEndpoints.GetAllBooks);
app.MapGet("/books{id}", BookEndpoints.GetBook);
app.MapPut("/book{id}", BookEndpoints.UpdateBook);
app.MapDelete("/books{id}", BookEndpoints.DeleteBook);



app.Run();

