
using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using exercise.wwwapi.Models.Payload;

namespace exercise.Endpoints {
    public static class StudentEndpoint {

        public static void ConfigureStudentEndpoint(this WebApplication app) {
            var students = app.MapGroup("students");
            students.MapGet("/", GetAllStudents);
            students.MapPost("/", CreateStudent);
            students.MapGet("/{FirstName}", GetStudent);
            students.MapPut("/{FirstName}", UpdateStudent);
            students.MapDelete("/{FirstName}", DeleteStudent);
        }

    public static IResult CreateStudent(IStudentRepository sr, StudentPostPayload payload)
    {
        if (payload == null)
        {
            return Results.BadRequest("Payload cannot be null");
        }

        Student student = sr.AddStudent(payload.FirstName, payload.LastName);
        return TypedResults.Created($"/tasks/{student.FirstName}", student);
    }

    public static IResult DeleteStudent(IStudentRepository sr, string FirstName)
    {
        if (FirstName == null)
        {
            return Results.BadRequest("FirstName cannot be null");
        }

        var deletedStudent = sr.DeleteStudent(FirstName);

        if (deletedStudent == null)
        {
            return Results.NotFound($"Student with FirstName {FirstName} not found.");
        }

        return TypedResults.Ok(deletedStudent);
    }

    public static IResult GetStudent(IStudentRepository sr, string FirstName)
    {
        var student = sr.GetStudent(FirstName);

        if (student == null)
        {
            return Results.NotFound($"Student with FirstName {FirstName} not found.");
        }

        return TypedResults.Ok(student);
    }

    public static IResult GetAllStudents(IStudentRepository sr)
    {
        return TypedResults.Ok(sr.GetAllStudents());
    }

    public static IResult UpdateStudent(IStudentRepository students, string FirstName, StudentUpdatePayload payload)
    {
        try
        {
            if (payload == null)
            {
                return Results.BadRequest("Payload cannot be null");
            }

            Student? student = students.UpdateStudent(FirstName, payload);

            if (student == null)
            {
                return Results.NotFound($"Student with FirstName {FirstName} not found.");
            }

            return Results.Ok(student);
        }
        catch (Exception e)
        {
            return Results.BadRequest(e.Message);
        }
    }
    }
}