using System.Runtime.CompilerServices;
using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentsEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var students = app.MapGroup("students");

            students.MapPost("/", AddStudent);
            students.MapGet("/", GetStudents);
            students.MapGet("/{firstName}", GetStudent);
            students.MapPut("/{firstName}", UpdateStudent);
            students.MapDelete("/{firstName}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddStudent(IStudentRepository repository, Student student)
        {
            repository.Add(student);

            //return Results.Ok(student);
            return TypedResults.Created($"https://localhost:7068/students/{student.FirstName}", student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IStudentRepository repository)
        {
            return Results.Ok(repository.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudent(IStudentRepository repository, string firstName)
        {
            return Results.Ok(repository.Get(firstName));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateStudent(IStudentRepository repository, string firstName, Student student)
        {
            repository.Update(firstName, student);

            return Results.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IStudentRepository repository, string firstName)
        {
            repository.Delete(firstName);

            return Results.Ok();
        }
    }
}
