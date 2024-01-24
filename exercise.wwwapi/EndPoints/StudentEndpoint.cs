using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace exercise.wwwapi.EndPoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var studentGroup = app.MapGroup("student");

            studentGroup.MapPost("/Create a student/", CreateStudent);
            studentGroup.MapGet("/Get a student {firstname}/", GetAStudent);
            studentGroup.MapGet("/Get all students/", GetAllStudents);
            studentGroup.MapPut("/Update a student {firstname}/", UpdateStudent);
            studentGroup.MapDelete("/Delete a student {firstname}/", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateStudent(IRepository repository, Student student)
        {
            repository.AddStudent(student);
            return TypedResults.Created($"https://localhost:7206/students/{student.FirstName}", student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAStudent(IRepository repository, string firstname)
        {
            Student test = repository.GetAStudent(firstname);
            if (test == null)
            {
                return Results.NotFound($"Id: {firstname} not found!");
            }
            return TypedResults.Ok(test);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllStudents(IRepository repository)
        {
            return TypedResults.Ok(repository.GetStudents());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateStudent(IRepository repository, string firstname, Student student)
        {
            Student test = repository.UpdateStudent(firstname, student);
            if (test == null)
            {
                return Results.NotFound($"Id: {firstname} not found!");
            }
            return TypedResults.Ok(test);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository repository, string firstname)
        {
            Student test = repository.GetAStudent(firstname);
            return test == null ? Results.NotFound($"Id: {firstname} not found!") : TypedResults.Ok(repository.DeleteAStudent(firstname));
        }
    }
}
