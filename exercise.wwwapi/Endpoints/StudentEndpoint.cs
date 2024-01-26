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
            studentGroup.MapPost("/", AddStudent);
            studentGroup.MapGet("/", GetStudents);
            studentGroup.MapGet("/{firstName}", GetStudent);
            studentGroup.MapPut("/{firstName}", UpdateStudent);
            studentGroup.MapDelete("/{firstName}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            return TypedResults.Ok(repository.GetStudents());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudent(IRepository repository, string firstName)
        {
            return TypedResults.Ok(repository.GetStudentById(firstName));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddStudent(IRepository repository, Student student)
        {
            Student result = repository.InsertStudent(student);
            return TypedResults.Created($"{student.FirstName}", result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateStudent(IRepository repository, string firstName, Student student)
        {
            Student result = repository.UpdateStudent(firstName, student);
            return TypedResults.Created($"{student.FirstName}", student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository repository, string firstName)
        {
            return TypedResults.Ok(repository.DeleteStudent(firstName));
        }
    }
}
