using exercise.wwwapi.Interfaces;
using exercise.wwwapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoints
    {
        public static void ConfigureStudentEndpoints(this WebApplication app)
        {
            var studentGroup = app.MapGroup("students");
            studentGroup.MapGet("/" , GetAllStudents);
            studentGroup.MapPost("/" , CreateStudent);
            studentGroup.MapPut("/{firstName}" , UpdateStudent);
            studentGroup.MapDelete("/{firstName}" , DeleteStudent);
        }

        public static IResult GetAllStudents([FromServices] IStudentRepository students)
        {
            return Results.Ok(students.GetAll());
        }

        public static IResult CreateStudent([FromServices] IStudentRepository students , Student newStudentData)
        {
            Student student = students.Add(newStudentData);
            return Results.Created($"/students/{student.FirstName}" , student);
        }

        public static IResult UpdateStudent([FromServices] IStudentRepository students , string firstName , Student updatedStudentData)
        {
            Student? student = students.Update(firstName , updatedStudentData);
            if(student == null)
            {
                return Results.NotFound($"Student with first name {firstName} not found.");
            }
            return Results.Ok(student);
        }

        public static IResult DeleteStudent([FromServices] IStudentRepository students , string firstName)
        {
            Student? student = students.Delete(firstName);
            if(student == null)
            {
                return Results.NotFound($"Student with first name {firstName} not found.");
            }
            return Results.Ok(student);
        }
    }
}

