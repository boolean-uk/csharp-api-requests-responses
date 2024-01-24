using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var studentGroup = app.MapGroup("students");

            studentGroup.MapGet("", GetStudent);
            studentGroup.MapPost("", CreateStudent);
            studentGroup.MapGet("/{firstName}", FindStudent);
            studentGroup.MapPut("/{firstName}", UpdateStudent);
            studentGroup.MapDelete("/{firstName}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetStudent(IRepository repository)
        {
            if (!repository.GetAllStudents().Any()) return TypedResults.NotFound();
            return TypedResults.Ok(repository.GetAllStudents());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateStudent(IRepository repository, Student student)
        {
            if ( student.FirstName == String.Empty | student.LastName == String.Empty) return TypedResults.BadRequest();
            repository.CreateStudent(student);
            return TypedResults.Created($"https://localhost:7068/students/{student.FirstName}", student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> FindStudent(IRepository repository, string firstName)
        {
            Student student = repository.FindStudent(firstName);
            if ( student == null ) return TypedResults.NotFound();
            return TypedResults.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateStudent(IRepository repository, Student student, string firstName)
        {
            Student newStudent = repository.FindStudent(firstName);
            if (student == null) return TypedResults.NotFound();
            if (student.FirstName == String.Empty | student.LastName == String.Empty) return TypedResults.BadRequest();
            newStudent.rename(student.FirstName, student.LastName);
            return TypedResults.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IRepository repository, string firstName)
        {
            Student student = repository.FindStudent(firstName);
            if ( student == null) return TypedResults.NotFound();
            repository.removeStudent(firstName);
            return TypedResults.Ok(student);
        }
    }
}
