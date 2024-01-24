using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.EndPoints
{
    public static class studentEndPoints
    {
        public static void StudentEndPointConfig(this WebApplication app)
        {
            var studentGroup = app.MapGroup("students");

            studentGroup.MapPost("/CreateNewStudent", CreateAStudent);
            studentGroup.MapGet("/GetAllStudents", GetAllStudents);
            studentGroup.MapGet("/GetAStudent{firstName}", GetAStudent);
            studentGroup.MapPut("/UpdateAStudent{firstName}", UpdateAStudent);
            studentGroup.MapDelete("/DeleteAStudent{firstName}", DeleteAStudent);
        }

        public static IResult CreateAStudent(IStudentRepository students, StudentPostPayload newStudentData)
        {
            students.CreateAStudent(newStudentData.firstName,newStudentData.lastName);
            return TypedResults.Ok(students);
        }

        public static IResult GetAllStudents(IStudentRepository student)
        {
            return TypedResults.Ok(student.GetAllStudents());
        }

        public static IResult GetAStudent(IStudentRepository student, string firstName)
        {
            return TypedResults.Ok(student.GetAStudent(firstName));
        }

        public static IResult UpdateAStudent(IStudentRepository student,string firstName, StudentUpdateData updateData)
        {

            return TypedResults.Ok(student.UpdateAStudent(firstName,updateData));
        }
        public static IResult DeleteAStudent(IStudentRepository student, string firstName)
        {
            return TypedResults.Ok(student.DeleteAStudent(firstName));
        }
    }
}
