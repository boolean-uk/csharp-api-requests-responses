
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

        private static async Task<IResult> CreateStudent(IRepository<Student> repository, Student student)
        {
            repository.Add(student);
            return TypedResults.Created(student.FirstName, student);
        }
        private static async Task<IResult> AllStudents(IRepository<Student> repository)
        {
            return TypedResults.Ok(repository.Get());
        }
        private static async Task<IResult> Student(IRepository<Student> repository, string firstName)
        {
            Student student = repository.GetById(firstName);

            return TypedResults.Ok(student);
        }
        private static async Task<IResult> UpdateStudent(IRepository<Student> repository,string firstName, Student student)
        {
            repository.Update(firstName, student);
            return TypedResults.Ok(student);
        }
        private static async Task<IResult> DeleteStudent(IRepository<Student> repository, string name)
        {
            Student student = repository.GetById(name);
            repository.Delete(name);
            return TypedResults.Ok(student);
        }
    }
}
