using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var studentGroup = app.MapGroup("student");

            studentGroup.MapGet("/students", GetStudents);
            studentGroup.MapGet("/{FirstName}", GetStudent);
            studentGroup.MapPut("/{FirstName}", UpdateStudent);
            studentGroup.MapDelete("/{FirstName}", DeleteStudent);
            studentGroup.MapPost("/{FirstName}", CreateStudent);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            return TypedResults.Ok(repository.GetStudents());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudent(IRepository repository, string FirstName)
        {
            return TypedResults.Ok(repository.GetStudent(FirstName));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateStudent(IRepository repository, string FirstName, string NewFirstName)
        {
            return TypedResults.Ok(repository.UpdateStudent(FirstName, NewFirstName));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository repository, string FirstName)
        {
            return TypedResults.Ok(repository.DeleteStudent(FirstName));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateStudent(IRepository repository, string FirstName, string LastName)
        {
            return TypedResults.Ok(repository.CreateStudent(FirstName, LastName));
        }

    }
}
