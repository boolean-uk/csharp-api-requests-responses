using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<StudentCollection>();
builder.Services.AddSingleton<LanguageCollection>();
builder.Services.AddSingleton<BookCollection>();
//builder.Services.AddSingleton<Student>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Create a student
app.MapPost("/CreateNewStudent", (string firstname, string lastname, StudentCollection students) =>
{
    Student newStudent = new Student() { FirstName = firstname, LastName = lastname };
    students.Add(newStudent); //(new Student() { FirstName = firstname, LastName = lastname });
    List<Student> studentList = students.getAll();
    return TypedResults.Created("/CreateNewStudent",newStudent);
});

//Get all students
// /GetAllStudents:Route for http getrequest, this API endpoint will be accessible at this route
// (StudentCollection Students) =>, lambda expression that defines inline function to be executed
//When a request os is made is made to /StudentCollection endpoint
// function takes a parameter students of type: StudentCollection
//Return Typed Results ok = 200 response
//the (studentList) will be included in the body of response
app.MapGet("/GetAllStudents", (StudentCollection students) =>
{
    List<Student> studentList = students.getAll();
    return TypedResults.Ok(studentList);
});

//Get one student by firstname
app.MapGet("/GetStudentByName", (string firstname, StudentCollection students) =>
{
    List<Student> studentList = students.getAll();

    var studentToReturn = studentList.FirstOrDefault(s => s.FirstName == firstname);

    return TypedResults.Ok(studentToReturn);
});

//Update a student
app.MapPut("/UpdateStudent", (string firstname, string newFirstname, string newLastname, StudentCollection students) =>
{
    Student student = students.replaceStudent(firstname, newFirstname, newLastname);

    //List<Student> studentList = students.getAll();
    return TypedResults.Created("/UpdateStudent",student);
});

//Delete a student
app.MapDelete("/DeleteStudent", (string firstname, StudentCollection students) =>
{
    List<Student> studentList = students.getAll();

    var student = studentList.FirstOrDefault(s => s.FirstName == firstname);

    if (student != null)
    {
        studentList.Remove(student);
    }
    
    return TypedResults.Ok(studentList);
});

//Create a language
app.MapPost("/CreateLanguage", (string languageName, LanguageCollection languages) =>
{
    languages.AddLanguage(new Language(languageName));
    List<Language> languageList = languages.GetList();
    return TypedResults.Created ("/CreateLanguage", languageList);
});

//get all languages
app.MapGet("/GetAllLanguages", (LanguageCollection languages) =>
{
    List<Language> languageList = languages.GetList();
    return TypedResults.Ok(languageList);
});

//get one language
app.MapGet("/GetLanguageByName", (string languageName,LanguageCollection languages) =>
{
    Language language = languages.GetLanguageByName(languageName);
    return TypedResults.Ok(language);
});

//update one language
app.MapPut("/UpdateLanguageByName", (string languageName, string newName, LanguageCollection languages) =>
{
    List<Language> languageList = languages.GetList();
    languages.updateLanguageByName(languageName, newName); 



    return TypedResults.Created("/UpdateLanguageByName",languageList);
});

app.MapDelete("/DeleteLanguage", (string languageName, LanguageCollection languages) =>
{
    List<Language> languageList = languages.GetList();

    var language = languageList.FirstOrDefault(l => l.name == languageName);

    if (language != null)
    {
        languageList.Remove(language);
    }

    return TypedResults.Ok(languageList);
});

app.MapPost("/CreateNewBook", (string title, int numPages, string author, string genre, BookCollection library) =>
{
    Book book = library.AddBook(title, numPages, author, genre);
    return TypedResults.Created($"",book);
});


app.Run();

