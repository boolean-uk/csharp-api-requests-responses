using exercise.wwwapi.Data;
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

            students.MapGet("/", GetAllStudents);
            students.MapGet("/{firstName}", GetAStudent);
            students.MapPost("/", CreateAStudent);
            students.MapPut("/{firstName}", UpdateAStudent);
            students.MapDelete("/{firstName}", DeleteAStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllStudents(IRepository<Student> repository)
        {
            return TypedResults.Ok(repository.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAStudent(IRepository<Student> repository, string firstName)
        {
            Payload<Student> payload = new Payload<Student>();
            payload.Data = repository.Get(firstName);

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult CreateAStudent(IRepository<Student> repository, Student student)
        {
            Payload<Student> payload = new Payload<Student>();
            payload.Data = repository.Create(student);

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UpdateAStudent(IRepository<Student> repository, string firstName, Student student)
        {
            Payload<Student> payload = new Payload<Student>();
            payload.Data = repository.Update(firstName, student);

            return TypedResults.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteAStudent(IRepository<Student> repository, string firstName)
        {
            var student = repository.Delete(firstName);

            return TypedResults.Ok(student);
        }
    }
}
