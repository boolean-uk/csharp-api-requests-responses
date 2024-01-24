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
            studentGroup.MapGet("/", GetAllStudents);
            studentGroup.MapPost("/", CreateStudent);
            studentGroup.MapGet("/{firstName}", GetStudent);
            studentGroup.MapDelete("/{firstName}", DeleteStudent);
            studentGroup.MapPut("/{firstName}", UpdateStudent);
        }

        public static IResult GetAllStudents(IStudentRepository students)
        {
            return TypedResults.Ok(students.GetAllStudents());
        }

        public static IResult GetStudent(IStudentRepository students, string firstName)
        {
            try
            {
                Student st = students.GetStudent(firstName);
                if (st == null)
                {
                    return Results.NotFound($"Student with name {firstName} not found.");
                }
                return Results.Ok(st);

            } catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
            
        }

        public static IResult DeleteStudent(IStudentRepository students, string firstName)
        {
            try
            {
                Student st = students.DeleteStudent(firstName);
                if (st == null)
                {
                    return Results.NotFound($"Student with name {firstName} not found.");
                }
                return Results.Ok(st);

            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }

        }

        public static IResult CreateStudent(IStudentRepository students, StudentPostPayload newStudentData)
        {
            if(newStudentData.FirstName.Length == 0 || newStudentData.LastName.Length == 0) 
            {
                return Results.NotFound($"Student needs first and last name to be created!");
            }

            Student st = students.AddStudent(newStudentData.FirstName, newStudentData.LastName);
            return TypedResults.Created($"/students{st.FirstName}", st);

        }

        public static IResult UpdateStudent(IStudentRepository students, string firstName, StudentUpdatePayload newStudentData)
        {

            try
            {
                Student? st = students.UpdateStudent(newStudentData);
                
                if (st == null)
                {
                    return Results.NotFound($"Student with name {newStudentData.FirstName} not found.");
                }
                // return Results.Ok(st);
                firstName = st.FirstName;
                return TypedResults.Created($"/students{st}", st);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }

        }
    }
}
