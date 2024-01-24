using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var studentGroup = app.MapGroup("students");

            studentGroup.MapGet("/", GetStudents);
            studentGroup.MapGet("/{firstName}", GetStudent);
            studentGroup.MapPost("/", AddStudent);
            studentGroup.MapPut("/{firstName}", UpdateStudent);
            studentGroup.MapDelete("/{firstName}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IStudentRepository repository)
        {
            return TypedResults.Ok(repository.Get());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudent(IStudentRepository repository, string firstName)
        {
            return TypedResults.Ok(repository.Get(firstName));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddStudent(IStudentRepository repository, Student student)
        {
            
            return TypedResults.Created("url", repository.Add(student));
        }

        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public static async Task<IResult> UpdateStudent(IStudentRepository repository, string firstName, Student student)
        {
            return TypedResults.Accepted("url", repository.Update(firstName, student));
        }

        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public static async Task<IResult> DeleteStudent(IStudentRepository repository, string firstName)
        {
            return TypedResults.Accepted("url", repository.Remove(firstName));
        }
    }
}
