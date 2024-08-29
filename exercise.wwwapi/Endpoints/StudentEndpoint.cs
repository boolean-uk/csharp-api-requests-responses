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
            students.MapPost("/", AddStudent);
            students.MapGet("/{firstName}", GetStudent);
            students.MapPut("/{firstName}", UpdateStudent);
            students.MapDelete("/", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetStudents(IRepository<Student> repository)
        {
            Payload<List<Student>> payload = new Payload<List<Student>>();
            payload.data = repository.GetClasses();
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult AddStudent(IRepository<Student> repository, Student student)
        {
            Payload<Student> payload = new Payload<Student>();
            payload.data = repository.AddClass(student);
            return TypedResults.Created($"http://localhost:5115/students/{payload.data.FirstName}", payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetStudent(IRepository<Student> repository, string firstName)
        {
            Payload<Student> payload = new Payload<Student>();
            payload.data = repository.GetClass(firstName);
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult UpdateStudent(IRepository<Student> repository, Student newStudent, string firstName)
        {
            Payload<Student> payload = new Payload<Student>();
            payload.data = repository.UpdateClass(newStudent, firstName);
            return TypedResults.Ok(payload);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteStudent(IRepository<Student> repository, string firstName)
        {
            Payload<Student> payload = new Payload<Student>();
            payload.data = repository.DeleteClass(firstName);
            return TypedResults.Ok(payload);
        }
    }
}
