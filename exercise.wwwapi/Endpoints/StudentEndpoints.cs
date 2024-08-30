using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoints
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapPost("/", AddStudents);
            students.MapGet("/", GetStudents);
            students.MapGet("/{firstName}", GetAStudent);
            students.MapPut("/{firstName}", UpdateAStudent);
            students.MapDelete("/{fistName}", DeleteStudent);
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult AddStudents(IRepository<Student> repository, Student student)
        {
            Payload<Student> payload = new();
            payload.data = repository.AddEntity(student);
            return payload.data != null ? TypedResults.Created($"https://localhost:7068/{student.FirstName}", payload.data) : TypedResults.BadRequest();
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetStudents(IRepository<Student> repository)
        {
            Payload<List<Student>> payload = new();
            payload.data = repository.GetEntities();
            return TypedResults.Ok(payload);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAStudent(IRepository<Student> repository, string firstName)
        {
            Payload<Student> payload = new();
            payload.data = repository.GetAEntity(firstName);
            return TypedResults.Ok(payload);
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult UpdateAStudent(IRepository<Student> repository, Student student, string firstName)
        {
            Payload<Student> payload = new();
            payload.data = repository.ChangeAnEntity(student, firstName);
            return payload.data != null ? TypedResults.Created($"https://localhost:7068/{firstName}", payload.data) : TypedResults.BadRequest();
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult DeleteStudent(IRepository<Student> repository, string firstName)
        {
            Payload<string> payload = new();
            payload.data = repository.DeleteAnEntity(firstName);
            return payload.data != null? TypedResults.Ok(payload): TypedResults.NotFound();
        }

    }
}
