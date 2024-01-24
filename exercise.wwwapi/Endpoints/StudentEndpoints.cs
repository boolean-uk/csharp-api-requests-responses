using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoints
    {
        public static void ConfigureStudentEndpoints(this WebApplication app)
        {
            var taskGroup = app.MapGroup("students");
            taskGroup.MapGet("/", GetAllStudents);
            taskGroup.MapPost("/", CreateStudent);
            taskGroup.MapGet("/{firstName}", GetAStudent);
            taskGroup.MapPut("/{firstName}", UpdateStudent);
            taskGroup.MapDelete("/{firstName}", DeleteStudent);
        }
        public static IResult GetAllStudents(IStudentRepository students)
        {
            return TypedResults.Ok(students.GetAllStudents());
        }

        public static IResult CreateStudent(IStudentRepository students, StudentPostPayload newStudentData)
        {
            Student student = students.AddStudent(newStudentData);
            return Results.Created("", student);
        }
        public static IResult GetAStudent(IStudentRepository students, string firstName)
        {
            Student? student = students.GetStudent(firstName);
            if (student is null) return TypedResults.NotFound();
            return TypedResults.Ok(student);
        }

        public static IResult UpdateStudent(IStudentRepository students, string firstName, StudentPostPayload newStudentData)
        {
            try
            {
                Student student = students.ChangeStudent(firstName, newStudentData);
                return Results.Created("", student);
            }
            catch
            {
                return Results.NotFound();
            }

        }
        public static IResult DeleteStudent(IStudentRepository students, string firstName)
        {
            try
            {
                Student student = students.DeleteStudent(firstName);
                return TypedResults.Ok(student);
            }
            catch
            {
                return Results.NotFound();
            }

        }

    }
}
