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
            students.MapGet("/{firstname}", GetStudent);
            students.MapPost("/", CreateStudent);
            students.MapPut("/{firstname}", UpdateStudent);
            students.MapDelete("/{firstname}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllStudents(IRepository<Student, string> repository)
        {
            return TypedResults.Ok(repository.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult CreateStudent(IRepository<Student, string> repository, Student student)
        {
            Student s = repository.Add(student);
            return TypedResults.Created("/", s);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult GetStudent(IRepository<Student, string> repository, string firstname)
        {
            Student s = repository.Get(firstname);
            return s != null ? TypedResults.Ok(s) : TypedResults.NotFound($"Student: {firstname} was not found");
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult UpdateStudent(IRepository<Student, string> repository, string firstname, Student student)
        {
            Student s = repository.Update(firstname, student);
            return s != null ? TypedResults.Created("/", s) : TypedResults.NotFound($"Student: {firstname} was not found");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult DeleteStudent(IRepository<Student, string> repository, string firstname)
        {
            Student s = repository.Delete(firstname);
            return s != null ? TypedResults.Ok(s) : TypedResults.NotFound($"Student: {firstname} was not found");
        }
    }
}
