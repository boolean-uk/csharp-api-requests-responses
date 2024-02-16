using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using System.Runtime.CompilerServices;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoints { 

        public static void ConfigureStudentEndpoints(this WebApplication app)
        {
            var studentGroup = app.MapGroup("/students");
            studentGroup.MapGet("/", GetAll);
            studentGroup.MapGet("/{firstName}", GetStudent);
            studentGroup.MapPost("/", AddStudent);
            studentGroup.MapPut("/{firstName}", UpdateStudent);
            studentGroup.MapDelete("/{firstName}", DeleteStudent);
        }
    
        public static IResult GetAll(IStudentRepository students) {
            return TypedResults.Ok(students.GetStudents());
        }

        public static IResult GetStudent(IStudentRepository students, string firstName)
        {
            Student student = students.GetStudent(firstName);
            if (student == null)
            {
                return Results.NotFound();
            }
            return TypedResults.Ok(student);
        }

        public static IResult AddStudent(IStudentRepository students, StudentCreatePayload studentData)
        {
            Student student = students.AddStudent(studentData);
            return TypedResults.Created($"/students{student.FirstName}", students.AddStudent(studentData));
        }

        public static IResult UpdateStudent(IStudentRepository students, string firstName, StudentUpdatePayload studentData)
        {
            Student student = students.UpdateStudent(firstName, studentData);
            if (student == null)
            {
                return Results.NotFound();
            }
            return TypedResults.Ok(student);
        }

        public static IResult DeleteStudent(IStudentRepository students, string firstName)
        {
            Student student = students.DeleteStudent(firstName);
            if (student == null)
            {
                return Results.NotFound();
            }
            return TypedResults.Ok();
        }
    }
}
