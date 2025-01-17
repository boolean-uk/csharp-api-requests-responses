using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var studentCollection = new StudentCollection();
var languageCollection = new LanguageCollection();
var bookCollection = new BookCollection();

// Student stuff
app.MapGet("/students", () => TypedResults.Ok(studentCollection.getAll()));

app.MapPost("/students", (Student student) =>
    TypedResults.Created($"/students/{studentCollection.Add(student).FirstName}", student));

app.MapGet("/students/{firstName}", IResult (string firstName) =>
{
    var student = studentCollection.getAll().FirstOrDefault(s => s.FirstName == firstName);
    
    if (student == null)
    {
        return TypedResults.NotFound();
    }
    
    return TypedResults.Ok(student);
});

app.MapPut("/students/{firstName}", IResult (string firstName, Student student) =>
{
    var existingStudent = studentCollection.getAll().FirstOrDefault(s => s.FirstName == firstName);
    if (existingStudent == null)
    {
        return TypedResults.NotFound();
    }
    
    existingStudent.FirstName = student.FirstName;
    existingStudent.LastName = student.LastName;
    return TypedResults.Ok(existingStudent);
});

app.MapDelete("/students/{firstName}", IResult (string firstName) =>
{
    var student = studentCollection.getAll().FirstOrDefault(s => s.FirstName == firstName);
    
    if (student == null)
    {
        return TypedResults.NotFound();
    }
    
    studentCollection.getAll().Remove(student);
    return TypedResults.NoContent();
});

// Language stuff
app.MapGet("/languages", () => TypedResults.Ok(languageCollection.getAll()));

app.MapPost("/languages", IResult (Language language) =>
{
    if (languageCollection.getAll().Any(l => l.Name == language.Name))
    {
        return TypedResults.Conflict();
    }
    
    return TypedResults.Created($"/languages/{languageCollection.Add(language).Name}", language);
});

app.MapGet("/languages/{name}", IResult (string name) =>
{
    var language = languageCollection.getAll().FirstOrDefault(lang => lang.Name == name);
    
    if (language == null)
    {
        return TypedResults.NotFound();
    }
    
    return TypedResults.Ok(language);
});

app.MapPut("/languages/{name}", IResult (string name, Language updatedLanguage) =>
{
    var language = languageCollection.getAll().FirstOrDefault(lang => lang.Name == name);
    if (language == null)
    {
        return TypedResults.NotFound();
    }
    
    language.Name = updatedLanguage.Name;
    
    return TypedResults.Ok(language);
});

app.MapDelete("/languages/{name}", IResult (string name) =>
{
    var language = languageCollection.getAll().FirstOrDefault(l => l.Name == name);
    
    if (language == null)
    {
        return TypedResults.NotFound();
    }
    
    var removed = languageCollection.Remove(language);
    if (!removed)
    {
        // Why did this happen? :(
        return TypedResults.InternalServerError();
    }
    
    return TypedResults.NoContent();
});

// Book stuff for extension
app.MapGet("/books", () => TypedResults.Ok(bookCollection.getAll()));

app.MapPost("/books", IResult (Book book) =>
    TypedResults.Created($"/books/{bookCollection.Add(book).Title}", book));

app.MapGet("/books/{id}", IResult (Guid id) =>
{
    var book = bookCollection.getAll().FirstOrDefault(b => b.Id == id);
    if (book == null)
    {
        return TypedResults.NotFound();
    }
    return TypedResults.Ok(book);
});

app.MapPut("/books/{id}", IResult (Guid id, Book book) =>
{
    var existingBook = bookCollection.getAll().FirstOrDefault(b => b.Id == id);
    if (existingBook == null)
    {
        return TypedResults.NotFound();
    }
    
    existingBook.Title = book.Title;
    existingBook.Author = book.Author;
    existingBook.NumPages = book.NumPages;
    existingBook.Genre = book.Genre;
    
    return TypedResults.Ok(existingBook);
});

app.MapDelete("/books/{id}", IResult (Guid id) =>
{
    var book = bookCollection.getAll().FirstOrDefault(b => b.Id == id);
    
    if (book == null)
    {
        return TypedResults.NotFound();
    }
    
    bookCollection.Remove(book);
    return TypedResults.NoContent();
});


app.Run();

