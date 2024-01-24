using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using System.Threading.Tasks;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoints
    {
        public static void ConfigureStudentEndpoints(this WebApplication app)
        {
            var studentGroup = app.MapGroup("students");
            studentGroup.MapGet("/GetAllStudents", GetAllStudents);
            studentGroup.MapGet("/GetStudent", GetStudent);
            studentGroup.MapPost("/CreateStudent", CreateStudent);
            studentGroup.MapPut("/UpdateStudent{firstName}", UpdateStudent);
            studentGroup.MapPut("/RemoveStudent{firstName}", RemoveStudent);
        }
        public static IResult GetAllStudents(IStudentRepository students)
        {
            return TypedResults.Ok(students.GetAllStudents());
        }
        public static IResult GetStudent(IStudentRepository students, string firstName)
        {
            return TypedResults.Ok(students.GetStudent(firstName));
        }
        public static IResult CreateStudent(IStudentRepository students, StudentPostPayload newStudentData)
        {
            Student student = students.AddStudent(newStudentData.firstName, newStudentData.lastName);
            return TypedResults.Created($"/students{student.FirstName}", student);
        }
        public static IResult UpdateStudent(IStudentRepository students, string firstName, StudentUpdatePayload updateData)
        {
            try
            {
                Student? student = students.UpdateStudent(firstName, updateData);
                if (student == null)
                {
                    return Results.NotFound($"Student with first name {firstName} not found.");
                }
                return Results.Created($"/students{student.FirstName}", student);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }
        public static IResult RemoveStudent(IStudentRepository students, string firstName)
        {
            return TypedResults.Ok(students.RemoveStudent(firstName));
        }
    }
}
