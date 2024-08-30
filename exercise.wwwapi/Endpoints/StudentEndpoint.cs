using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapGet("/", GetStudents);
            students.MapGet("/{firstName}", GetStudent);
            students.MapPost("/addstudent", AddStudent);
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

        [ProducesResponseType(StatusCodes.Status200OK)]

        public static IResult GetStudent(IRepository<Student> repository, string firstName)
        {
            Payload<Student> payload = new Payload<Student>();
            payload.data = repository.Get(firstName);
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult AddStudent(IRepository<Student> repository, Student model)
        {

            Payload<Student> payload = new Payload<Student>();
            payload.data = repository.Add(model);

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UpdateStudent(IRepository<Student> repository, Student newStudent, string firstName)
        {

            Payload<Student> payload = new Payload<Student>();
            payload.data = repository.Update(newStudent, firstName);

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteStudent(IRepository<Student> repository, string firstName)
        {
            return TypedResults.Ok(repository.Delete(firstName));
        }
    }
}
