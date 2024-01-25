using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentsEndpoints
    {
        public static void ConfigureStudentsEndpoint(this WebApplication app)
        {
            var studentsGroup = app.MapGroup("students");

            studentsGroup.MapPost("/", PostStudent);
            studentsGroup.MapGet("/", GetStudents);
            studentsGroup.MapGet("/{firstName}", GetOneStudent);
            studentsGroup.MapPut("/{firstName}", PutStudent);
            studentsGroup.MapDelete("/{firstName}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)] //status code 200 : Success
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var result = repository.GetStudents();
            if (result != null)
            {
                return TypedResults.Ok(result);
            }
            return TypedResults.NoContent();
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOneStudent(IRepository repository, string firstName)
        {
            var result = repository.GetOneStudent(firstName);
            if (result != null)
            {
                return TypedResults.Ok(result);
            }
            return TypedResults.NotFound();
        }
        [ProducesResponseType(StatusCodes.Status201Created)] //status code 201 : Created
        public static async Task<IResult> PostStudent(IRepository repository, Student student)
        {
            var result = repository.AddStudent(student);
            if (result != null)
            {
                return TypedResults.Ok(result);
            }
            return TypedResults.NotFound();
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> PutStudent(IRepository repository, string firstName, Student student)
        {
            var result = repository.UpdateStudent(firstName, student);
            if (result != null)
            {
                return TypedResults.Ok(result);
            }
            return TypedResults.NotFound();
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository repository, string firstName)
        {
            var result = repository.DeleteStudent(firstName);
            if (result != null)
            {
                return TypedResults.Ok(result);
            }
            return TypedResults.NotFound();
        }
    }
}