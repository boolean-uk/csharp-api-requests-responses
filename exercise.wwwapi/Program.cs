using exercise.wwwapi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<StudentCollection>();
builder.Services.AddScoped<StudentsRepository>();
builder.Services.AddSingleton<LanguageCollection>();
builder.Services.AddScoped<LanguagesRepository>();
builder.Services.AddSingleton<BookCollection>();
builder.Services.AddScoped<BooksRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.ConfigureStudentsEndpoint();
app.ConfigureLanguagesEndpoint();
app.ConfigureBooksEndpoint();

app.Run();

