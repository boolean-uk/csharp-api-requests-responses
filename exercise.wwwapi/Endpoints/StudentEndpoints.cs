using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using System.Net.NetworkInformation;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoints
    {
        public static void configureStudentEndpoints(this WebApplication app)
        {
            var studentGroup = app.MapGroup("students");

            studentGroup.MapGet("/getAll", GetAllStudents);
            studentGroup.MapPost("/create", CreateNewStudent);
            studentGroup.MapPut("/update", UpdateStudent);

            studentGroup.MapGet("/get", GetStudentItem);
            studentGroup.MapDelete("/remove", DeleteStudent);

        }
        
        public static IResult DeleteStudent(IStudentRepository students, string name) 
        {
            return TypedResults.Ok(students.DeleteStudent(name));
        }
        public static IResult GetAllStudents(IStudentRepository students)
        {
            return TypedResults.Ok(students.GetAllStudents());
        }
        
        
        public static IResult GetStudentItem(IStudentRepository students, string firstname) 
        {
            return TypedResults.Ok(students.GetStudentItem(firstname));
        }
        

        public static IResult CreateNewStudent(IStudentRepository students, StudentItemPost newStudentData) 
            {
                return TypedResults.Created("/CreateNewStudent", students.Add(newStudentData.firstname, newStudentData.lastname));
            }

        public static IResult UpdateStudent(IStudentRepository students, string firstname, StudentItemUpdate updateData)
        {
            try
            {
                Student? student = students.UpdateStudent(firstname, updateData);
                if (student == null)
                {
                    return Results.NotFound("Student not found");
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

