namespace exercise.wwwapi.Endpoints;

using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

public static class StudentEndpoint
{
    public static void ConfigureStudentEndpoint(this WebApplication app)
    {
        var students = app.MapGroup("students");
        students.MapGet("/", GetAll);
        students.MapPost("/", Create);
        students.MapGet("/{firstname}", Get);
        students.MapPut("/update/{firstname}", Update);
        students.MapDelete("/{firstname}", Delete);
    }

    public static async Task<IResult> GetAll(IRepository<Student, Student> repository)
    {
        return Results.Ok(repository.GetAll());
    }

    public static async Task<IResult> Create(IRepository<Student, Student> repo, Student student)
    {
        //TODO: add good string
        // All fields required, so no LanguagePost
        return Results.Created($"{student.FirstName}", repo.Create(student));
    }

    public static async Task<IResult> Get(IRepository<Student, Student> repo, string firstname)
    {
        return Results.Ok(repo.Get(s => s.FirstName == firstname));
    }

    public static async Task<IResult> Update(
        IRepository<Student, Student> repo,
        string firstname,
        Student updated
    )
    {
        return Results.Created(
            $"{updated.FirstName}",
            repo.Update(l => l.FirstName == firstname, updated)
        );
    }

    public static async Task<IResult> Delete(IRepository<Student, Student> repo, string firstname)
    {
        return Results.Ok(repo.Delete(l => l.FirstName == firstname));
    }
}
