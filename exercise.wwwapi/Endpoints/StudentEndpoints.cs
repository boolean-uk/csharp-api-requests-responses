using exercise.wwwapi.Models.Student;
using exercise.wwwapi.Repository.Interfaces;

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
            students.MapPut("/{firstName}", UpdateStudent);
            students.MapDelete("/{firstName}", DeleteStudent);

        }

        public static IResult CreateStudent(IStudentRepo students, StudentPayload payLoad)
        {
            if (payLoad == null) { return Results.BadRequest("Empty payload"); }
            Student student = new Student();
            student.FirstName = payLoad.FirstName;
            student.LastName = payLoad.LastName;
            students.Add(student);
            return TypedResults.Created($"/students/{student.FirstName}", student);
        }

        public static IResult GetAllStudents(IStudentRepo students)
        {
            return TypedResults.Ok(students.GetAll());
        }

        public static IResult GetAStudent(IStudentRepo students, string firstName)
        {
            var student = students.Get(firstName);
            if (student == null) { return Results.NotFound($"No student with name {firstName} was found"); }
            return TypedResults.Ok(student);
        }

        public static IResult UpdateStudent(IStudentRepo students, string firstName, StudentPayload updatePayload)
        {
            var student = students.Update(firstName, updatePayload);
            if (student == null) { return Results.NotFound("Student not found"); }
            return TypedResults.Created($"/students/{student.FirstName}", student);
        }

        public static IResult DeleteStudent(IStudentRepo students, string firstName)
        {
            var student = students.Remove(firstName);
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
