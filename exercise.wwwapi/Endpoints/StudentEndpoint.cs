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

            studentGroup.MapPost("/", CreateStudent);
            studentGroup.MapGet("/", GetStudents);
            studentGroup.MapGet("/{firstName}", GetStudentByFirstName);
            studentGroup.MapPut("/{firstName}", UpdateStudentName);
            studentGroup.MapDelete("/{firstName}", DeleteAStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            return TypedResults.Ok(repository.GetStudents());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetStudentByFirstName(IRepository repository, string firstName)
        {
            Student? student = repository.GetStudentByFirstName(firstName);
            if (student != null)
            {
                return TypedResults.Ok(student);
            }
            else 
            {
                return TypedResults.NotFound($"Could not find student with the first name of {firstName}");
            }
            
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateStudent(IRepository repository, string firstName, string lastName)
        {

            return TypedResults.Created($"/students/{firstName}", repository.PostStudent(firstName, lastName));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateStudentName(IRepository repository, string firstName, string newFirstName, string newLastName)
        {
            Student? student = repository.UpdateStudentByFirstName(firstName, newFirstName, newLastName);
            if (student != null)
            {
                return TypedResults.Created($"/students/{newFirstName}", student);
            }
            else 
            {
                return TypedResults.NotFound($"Student with {firstName} was not found.");
            }
            
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteAStudent(IRepository repository, string firstName) 
        {
            Student? student = repository.DeleteStudentByFirstName(firstName);
            if (student != null)
            {
                return TypedResults.Ok(student);
            }
            else
            {
                return TypedResults.NotFound($"Could not find student with the first name of {firstName}");
            }
        }
    }
}
