using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoints
    {
        public static void ConfigureStudentEndpoints(this WebApplication app)
        {
            var students = app.MapGroup("/students");

            students.MapPost("", CreateStudent);
            students.MapGet("", GetAllStudents);
            students.MapGet("/{firstName}", GetAStudent);
            students.MapPatch("/{firstName}", UpdateStudent);
            students.MapDelete("/{firstName}", DeleteStudent);

        }

        public static IResult CreateStudent(IStudentRepository students, StudentPostPayload studentPostPayload)
        {
            Student student = new Student();
            student.FirstName = studentPostPayload.FirstName;
            student.LastName = studentPostPayload.LastName;
            students.AddStudent(student);
            return TypedResults.Created($"/students/{student.FirstName}", student);
        }

        public static IResult GetAllStudents(IStudentRepository students)
        {
            return TypedResults.Ok(students.GetAllStudents());
        }

        public static IResult GetAStudent(IStudentRepository students, string firstName)
        {
            var student = students.GetAStudent(firstName);
            if (student == null) { return Results.NotFound($"No student with name {firstName} was found"); }
            return TypedResults.Ok(student);
        }

        public static IResult UpdateStudent(IStudentRepository students, string firstName, StudentUpdatePayload updatePayload)
        {
            var student = students.UpdateStudent(firstName, updatePayload);
            if (student == null) { return Results.NotFound("Student not found"); }
            return TypedResults.Created($"/students/{firstName}", student);
        }

        public static IResult DeleteStudent(IStudentRepository students, string firstName)
        {
            var student = students.DeleteStudent(firstName);
            if (student == null)
            {
                return Results.NotFound("Student not found");
            }
            else
            {
                return TypedResults.Ok(student);
            }
        }
    }
}
