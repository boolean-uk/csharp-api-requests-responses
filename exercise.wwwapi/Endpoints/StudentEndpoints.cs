using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoints
    {
        public static void ConfigureStudentEndpoints(this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapGet("/", GetStudents);
            students.MapPost("/", AddStudent);
            students.MapGet("/{firstname}", GetAStudent);
            students.MapPut("/{firstname}", UpdateStudent);
            students.MapDelete("/{firstname}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult AddStudent(IRepository<Student> repository, Student student)
        {
            Payload<Student> payload = new Payload<Student>();
            payload.Data = repository.Add(student);
            return TypedResults.Created($"/students", payload);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetStudents(IRepository<Student> repository)
        {
            Payload<List<Student>> payload = new Payload<List<Student>>();
            payload.Data = repository.GetAll();
            return TypedResults.Ok(payload);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAStudent(IRepository<Student> repository, string firstname)
        {
            Payload<Student> payload = new Payload<Student>();
            payload.Data = repository.GetOne(firstname);
            return TypedResults.Ok(payload);
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UpdateStudent(IRepository<Student> repository, string firstname, string updatedName)
        {
            Payload<Student> payload = new Payload<Student>();
            payload.Data = repository.Update(firstname, updatedName);
            return TypedResults.Created("$/students}", payload);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteStudent(IRepository<Student> repository, string firstname)
        {
            Payload<Student> payload = new Payload<Student>();
            payload.Data = repository.Delete(firstname);
            return TypedResults.Ok(payload);
        }


    }
}
