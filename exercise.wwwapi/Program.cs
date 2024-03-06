using Microsoft.EntityFrameworkCore;
using exercise.wwwapi.Data;
using exercise.wwwapi.Endpoints;
using exercise.wwwapi.Models;
using exercise.wwwapi.Models.DTO;
using exercise.wwwapi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); //for minimal APIs only
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("StudentsDatabase"));
builder.Services.AddScoped<IRepository<Student>, Repository<Student>>();
builder.Services.AddScoped<IRepository<Language>, Repository<Language>>();
builder.Services.AddScoped<IRepository<Book>, Repository<Book>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//Configure Endpoints:
app.ConfigureStudentEndpoint();
app.ConfigureLanguageEndpoint();
app.ConfigureBookEndpoint();


//Put data in database:
app.MapGet("/seed", (IRepository<Language> languageRepository, IRepository<Student> studentRepository, IRepository<Book> bookRepository) =>
{
    LanguageCollection collection = new LanguageCollection();
    StudentCollection studentscoll = new StudentCollection();
    BookCollection books = new BookCollection();
    collection.languages.ForEach(language => { languageRepository.Insert(language); });
    studentscoll._students.ForEach(student => { studentRepository.Insert(student); });
    books.library.ForEach(book => { bookRepository.Insert(book); });
});

//app.MapGet("/seed", (IRepository<Language> languageRepository, IRepository<Student> studentRepository) =>
//{
//    LanguageCollection collection = new LanguageCollection();
//    StudentCollection studentscoll = new StudentCollection();

//    collection.languages.ForEach(language => { languageRepository.Insert(language); });
//    studentscoll._students.ForEach(student => { studentRepository.Insert(student); });

//});

app.Run();

