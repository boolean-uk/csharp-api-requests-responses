using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoints
    {
        public static void ConfigureStudentEndpoints(this WebApplication app)
        {
            var taskGroup = app.MapGroup("/students");
            taskGroup.MapGet("/", GetAllStudents);
            taskGroup.MapGet("/{firstName}", GetStudent);
            taskGroup.MapPost("/", CreateStudent);
            taskGroup.MapPut("/{firstName}", UpdateStudent);
            taskGroup.MapDelete("/{firstName}", DeleteStudent);
        }

        public static IResult GetAllStudents(IStudentRepository students)
        {
            return TypedResults.Ok(students.GetAllStudents());
        }

        public static IResult GetStudent(IStudentRepository student, string firstName)
        {
            return TypedResults.Ok(student.GetStudent(firstName));
        }

        public static IResult CreateStudent(IStudentRepository students, StudentPostPayload newStudentData)
        {
            Student newStudent = students.AddStudent(newStudentData.FirstName, newStudentData.LastName);
            return TypedResults.Created($"/students {newStudent.StudentId}", newStudent);
        }

        public static IResult UpdateStudent(IStudentRepository students, string firstName, StudentUpdatePayload updateStudent)
        {
            try
            {
                Student? student = students.UpdateStudent(firstName, updateStudent);
                if (student == null)
                {
                    return Results.NotFound($"Student with name {firstName}, is not found.");
                }
                return TypedResults.Ok(student);
            }
            catch (Exception ex)
            {
                return Results.NotFound(ex.Message);
            }
        }

        public static IResult DeleteStudent(IStudentRepository students, string firstName)
        {

            if (students == null)
            {
                return Results.NotFound($"Student with first name {firstName} is not found.");
            }
            return TypedResults.Ok(students.DeleteStudent(firstName));
        }

    }
}
