using System.Runtime.CompilerServices;
using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentsEndpoint
    {

        public static void ConfigureStudentsEndpoints(this WebApplication app)
        {
            var students = app.MapGroup("students");

            students.MapGet("/", GetStudents);

            students.MapGet("/{name}", GetStudent);



            students.MapPost("/", AddStudents);

            students.MapDelete("/{name}", DeleteStudents);
            students.MapPut("/{name}", UpdateStudents);


        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        private static async Task<IResult> UpdateStudents(IRepository<Student> repository, string name,string firstname,string lastname)
        {
            var student = repository.UpdateEntity(name, firstname, lastname);
            return Results.Ok(student);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetStudent(IRepository<Student> repository, string name)
        {
            var student= repository.GetEntity(name);
            return Results.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> DeleteStudents(IRepository<Student> repository,string name)
        {
            var deleted= repository.DeleteEntity(name);

            return Results.Ok(deleted);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        private static async Task<IResult> AddStudents(IRepository<Student> repository, Student student)
        {
            repository.AddEntity(student);

            return Results.Ok(student);

           
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetStudents(IRepository<Student> repository)
        {
            var students = repository.GetCollection();
            return Results.Ok(students);

        }
    }
}
