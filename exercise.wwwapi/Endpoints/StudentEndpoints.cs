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
        public static IResult AddStudent(IRepository<Student, string> repository, Student entity)
        {
            Student student = repository.Add(entity);
            return TypedResults.Created($"/students", student);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetStudents(IRepository<Student, string> repository)
        {
            return TypedResults.Ok(repository.GetAll());
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAStudent(IRepository<Student, string> repository, string firstname)
        {
            Student student = repository.GetOne(firstname);
            return student != null ? TypedResults.Ok(student) : TypedResults.NotFound();
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UpdateStudent(IRepository<Student, string> repository, string firstname, Student entity)
        {
            Student student = repository.Update(firstname, entity);
            return TypedResults.Created("$/students}", student);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteStudent(IRepository<Student, string> repository, string firstname)
        {
            Student student = repository.Delete(firstname);
            return TypedResults.Ok(student);
        }


    }
}
