using System.Runtime.CompilerServices;
using exercise.wwwapi.Repository;
using exercise.wwwapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace exercise.wwwapi.EndPoints
{
    public static class StudentEndpoints
    {
        public static void ConfigureStudentEndpoints(this WebApplication app)
        {
            var students = app.MapGroup("students");

            students.MapGet("/", GetAll);
            students.MapPost("/", Add);
            students.MapGet("/{firstName}", GetOne);
            students.MapDelete("/{firstName}", Delete);
            students.MapPut("/{firstName}", Update);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAll(IRepository<Student> repository)
        {
            var studentRepository = repository.GetAll();
            return TypedResults.Ok(studentRepository);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetOne(IRepository<Student> repository, string firstName)
        {
            var student = repository.GetOne(firstName);
            return TypedResults.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static Created<Student> Add(IRepository<Student> repository, Student student)
        {
            repository.Add(student);
            return TypedResults.Created($"/{student.FirstName}", student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> Delete(IRepository<Student> repository, string firstName)
        {
            var student = repository.Delete(firstName);
            return Results.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult Update(IRepository<Student> repository, Student student, string firstName)
        {
            var updatedStudent = repository.Update(student, firstName);
            return TypedResults.Created($"/{updatedStudent.FirstName}", updatedStudent);
        }
    }
}
