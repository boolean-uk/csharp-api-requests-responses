using exercise.wwwapi.Repository;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void StudentLogics(this WebApplication app)
        {
            var studentGroup = app.MapGroup("students");
            studentGroup.MapGet("/", GetAllStudents);
            studentGroup.MapGet("/{id}", GetStudent);
            studentGroup.MapPost("/", CreateStudent);
            studentGroup.MapPost("/{id}", UpdateStudent);
            studentGroup.MapDelete("/{id}", DeleteStudent);
        }

        public static IResult GetAllStudents(IStudentRepository students)
        {
            return TypedResults.Ok(students.GetAllStudents());
        }

        public static IResult GetStudent(IStudentRepository students, int id)
        {
            Student? student = students.GetStudent(id);
            if (student == null)
                return Results.NotFound("ID out of scope");

            return TypedResults.Ok(students.GetStudent(id));
        }

        public static IResult CreateStudent(IStudentRepository students, StudentPostPayload createdStudent)
        {
            Student? newStudent = students.AddStudent(createdStudent.firstName, createdStudent.lastName);
            if (newStudent == null)
                return Results.NotFound("Could not create student");

            return TypedResults.Created($"/students{newStudent.FirstName} {newStudent.LastName}", newStudent);
        }
        
        public static IResult UpdateStudent(IStudentRepository students, StudentUpdatePayload posted, int id)
        {
            Student? student = students.GetStudent(id);
            if (student == null)
                return Results.NotFound("ID out of scope");

            student = students.UpdateStudent(student, posted);
            return TypedResults.Created($"/students{student.FirstName} {student.LastName}", student);
        }

        public static IResult DeleteStudent(IStudentRepository students, int id)
        {
            Student? student = students.GetStudent(id);
            if (student == null)
                return Results.NotFound("ID out of scope");

            return TypedResults.Ok(students.DeleteStudent(id));
        }
    }
}
