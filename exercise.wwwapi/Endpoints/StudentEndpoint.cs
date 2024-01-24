using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndPoints(this WebApplication app)
        {
            var studentGroup = app.MapGroup("students");

            studentGroup.MapGet("/", GetStudents);
            studentGroup.MapGet("/{firstName}", GetStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IStudentRepository repository)
        {
            return TypedResults.Ok(repository.GetStudents());
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetStudent(IStudentRepository repository, string firstName)
        {
            Student student = repository.GetStudent(firstName);
            if(student != null)
            {
                return TypedResults.Ok(student);
            }
            else
            {
                return TypedResults.NotFound($"Student with that first name does not exist.");
            }
        }
    }
}
