using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints;

public static class StudentEndpoint
{
    public static void ConfigureStudentEndpoint(this WebApplication app)
    {
        var studentGroup = app.MapGroup("students");

        studentGroup.MapPost("/create/", CreateStudent);
        studentGroup.MapGet("/", GetStudents);
        studentGroup.MapGet("/{firstName}", GetStudent);
        studentGroup.MapPut("/{firstName}", UpdateStudent);
        studentGroup.MapDelete("/{firstName}", DeleteStudent);
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    public static async Task<IResult> CreateStudent(IStudentRepository repository, Student student)
    {
        return TypedResults.Created($"/{student.FirstName}", repository.AddStudent(student));
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    public static async Task<IResult> GetStudents(IStudentRepository repository)
    {
        return TypedResults.Ok(repository.GetStudents());
    }
    
    [ProducesResponseType(StatusCodes.Status200OK)]
    public static async Task<IResult> GetStudent(IStudentRepository repository, string firstName)
    {
        var student = repository.GetStudents().FirstOrDefault(x => x.FirstName == firstName);

        if (student == null)
        {
            return Results.NotFound($"FirstName: {firstName} not found!");
        }

        return TypedResults.Ok(student);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    public static async Task<IResult> UpdateStudent(IStudentRepository repository, string firstName, Student student)
    {
        var toEdit = repository.GetStudents().FirstOrDefault(x => x.FirstName == firstName);

        if (toEdit == null)
        {
            return Results.NotFound($"firstName: {firstName} not found!");
        }

        toEdit.FirstName = student.FirstName;
        toEdit.LastName = student.LastName;
        return TypedResults.Ok(toEdit);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    public static async Task<IResult> DeleteStudent(IStudentRepository repository, string firstName)
    {
        var Deleted = repository.DeleteStudent(firstName);

        if (Deleted == null)
        {
            return Results.NotFound($"firstName: {firstName} not found!");
        }

        return TypedResults.Ok(Deleted);
    }
}
