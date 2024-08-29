using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapPost("/", CreateStudent);
            students.MapGet("/", GetAllStudents);
            students.MapGet("/{firstName}", GetAStudent);
            students.MapPut("/{firstName}", UpdateStudent);
            students.MapDelete("/{firstName}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult CreateStudent(IRepository<Student> repository, Student student)
        {
            var result = repository.Create(student);
            return TypedResults.Created($"http://localhost:5115/students/{result.FirstName}", result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllStudents(IRepository<Student> repository)
        {
            var result = repository.GetAll();
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAStudent(IRepository<Student> repository, string firstName)
        {
            var result = repository.Get(firstName);
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UpdateStudent(IRepository<Student> repository, Student student, string firstName)
        {
            var result = repository.Update(student, firstName);
            return TypedResults.Created($"http://localhost:5115/students/{result.FirstName}", result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteStudent(IRepository<Student> repository, string firstName)
        {
            var result = repository.Delete(firstName);
            return TypedResults.Ok(result);
        }
    }
}
