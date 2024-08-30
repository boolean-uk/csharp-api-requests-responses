using exercise.wwwapi.Interfaces;
using exercise.wwwapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.EndPoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapGet("/", GetAllStudents);
            students.MapGet("/{firstName}", GetSingleStudent);
            students.MapPost("/", CreateStudent);
            students.MapPut("/{firstName}", UpdateStudent);
            students.MapDelete("/{firstName}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllStudents(IRepository<Student> repository)
        {
            return TypedResults.Ok(repository.GetAll());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetSingleStudent(IRepository<Student> repository, string firstname)
        {

            return TypedResults.Ok(repository.Get(firstname));
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult CreateStudent(IRepository<Student> repository, Student student)
        {

            return TypedResults.Ok(repository.Create(student));

        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UpdateStudent(IRepository<Student> repository, Student student, string firstname)
        {
            return TypedResults.Ok(repository.Update(firstname, student));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteStudent(IRepository<Student> repository, string firstname)
        {

            var student1 = repository.Delete(firstname);
            return TypedResults.Ok(student1);
        }
    }

    }
