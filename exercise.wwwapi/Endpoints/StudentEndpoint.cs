using System.Diagnostics.Metrics;
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
            students.MapGet("/", GetStudents);
            students.MapGet("/{firstName}", GetAStudent);
            students.MapPost("/", AddStudent);
            students.MapPut("/{firstName}", UpdateStudent);
            students.MapDelete("/{firstName}", DeleteStudent);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetStudents(IRepository<Student> repository)
        {
            Payload<List<Student>> payload = new Payload<List<Student>>();
            payload.data = repository.GetAll();

            return TypedResults.Ok(payload);
        }

        [Route("{firstName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult GetAStudent(IRepository<Student> repository, string firstName)
        {
            Payload<Student> payload = new Payload<Student>();
            payload.data = repository.GetOne(firstName);

            return payload.data != null ? TypedResults.Ok(payload) : TypedResults.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult AddStudent(IRepository<Student> repository, Student student)
        {
            Payload<Student> payload = new Payload<Student>();
            payload.data = repository.Add(student);

            return TypedResults.Ok(payload);
        }

        [Route("{firstName}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UpdateStudent(IRepository<Student> repository, string firstName, Student student)
        {
            Payload<Student> payload = new Payload<Student>();
            payload.data = repository.Update(firstName, student);

            return TypedResults.Ok(payload);
        }

        [Route("{firstName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteStudent(IRepository<Student> repository, string firstName)
        {
            Payload<Student> payload = new Payload<Student>();
            payload.data = repository.Delete(firstName);

            return TypedResults.Ok(payload);
        }
    }
}
