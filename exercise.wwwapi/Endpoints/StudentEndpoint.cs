
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapGet("/", GetAll);
            students.MapGet("/{firstName}", Get);
            students.MapPost("/", Add);
            students.MapPut("/{firstName}", Update);
            students.MapDelete("/{firstName}", Delete);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAll(IRepository<Student, Student, string> repository)
        {
            return TypedResults.Ok(repository.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult Get(IRepository<Student, Student, string> repository, string firstName)
        {
            var result = repository.Get(firstName);
            return result != null ? TypedResults.Ok(result) : TypedResults.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult Add(IRepository<Student, Student, string> repository, Student entity)
        {
            var result = repository.Add(entity);
            return result != null ? TypedResults.Created($"https://localhost:7068/students/", result) : TypedResults.BadRequest();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult Update(IRepository<Student, Student, string> repository, string firstName, Student entity)
        {
            var result = repository.Update(firstName, entity);
            return result != null ? TypedResults.Created($"https://localhost:7068/students/{firstName}", result) : TypedResults.BadRequest();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult Delete(IRepository<Student, Student, string> repository, string firstName)
        {
            var result = repository.Delete(firstName);
            return result != null ? TypedResults.Ok(result) : TypedResults.NotFound();
        }

    }
}
