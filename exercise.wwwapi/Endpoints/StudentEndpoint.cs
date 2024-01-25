
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Builder;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var studentGroup = app.MapGroup("students");

            studentGroup.MapPost("/", CreateStudent); 
            studentGroup.MapGet("/", AllStudents);
            studentGroup.MapGet("/{firstName}", Student);
            studentGroup.MapPut("/{firstName}", UpdateStudent);
            studentGroup.MapDelete("/{firstName}", DeleteStudent);
        }

        private static async Task<IResult> CreateStudent(IRepository repository, Student student)
        {
            repository.AddStudent(student);
            return TypedResults.Created(student.FirstName, student);
        }
        private static async Task<IResult> AllStudents(IRepository repository)
        {
            return TypedResults.Ok(repository.GetStudents());
        }
        private static async Task<IResult> Student(IRepository repository, string firstName)
        {
            Student student = repository.GetStudent(firstName);

            return TypedResults.Ok(student);
        }
        private static async Task<IResult> UpdateStudent(IRepository repository,string firstName, Student student)
        {
            repository.UpdateStudent(firstName, student);
            return TypedResults.Ok(student);
        }
        private static async Task<IResult> DeleteStudent(IRepository repository, string name)
        {
            Student student = repository.GetStudent(name);
            repository.DeleteStudent(name);
            return TypedResults.Ok(student);
        }
    }
}
