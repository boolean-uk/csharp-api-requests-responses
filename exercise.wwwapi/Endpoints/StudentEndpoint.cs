using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapPost("/", CreateAStudent);
            students.MapGet("/", GetAllStudents);
            students.MapGet("/{firstName}", GetAStudent);
            students.MapPut("/{firstName}", UpdateStudent);
            students.MapDelete("/{firstName}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult CreateAStudent(IStudentRepository repository, Student student)
        {
            var result = repository.CreateAStudent(student);
            return result != null ? TypedResults.Created($"https://localhost:7068/students", result) : TypedResults.BadRequest();

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllStudents(IStudentRepository repository)
        {
            return TypedResults.Ok(repository.GetAllStudents());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult GetAStudent(IStudentRepository repository, string firstname)
        {
            if (repository.GetAStudent(firstname) != null)
            {
                return TypedResults.Ok(repository.GetAStudent(firstname));
            }
            return TypedResults.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult UpdateStudent(IStudentRepository repository, string firstname, string newFirstname, string newLastname)
        {
            var getStudent = repository.GetAStudent(firstname);
            if (getStudent != null)
            {
                var result = repository.UpdateStudent(firstname, newFirstname, newLastname);
                return result != null ? TypedResults.Created($"https://localhost:7068/students", result) : TypedResults.BadRequest();
            }
            return TypedResults.NotFound();

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult DeleteStudent(IStudentRepository repository, string firstName)
        {
            var student = repository.GetAStudent(firstName);
            if (student != null)
            {
                return TypedResults.Ok(repository.DeleteStudent(firstName));
            }
            return TypedResults.NotFound();

        }
    }
}
