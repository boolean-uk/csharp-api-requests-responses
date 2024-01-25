using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var studentGroup = app.MapGroup("students");

            studentGroup.MapGet("/", GetStudents);
            studentGroup.MapGet("/{firstName}", GetStudent);
            studentGroup.MapPost("/", AddStudent);
            studentGroup.MapPut("/{firstName}", UpdateStudent);
            studentGroup.MapDelete("/{firstName}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository<Student> repository)
        {
            return TypedResults.Ok(repository.GetAll());           
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudent(IRepository<Student> repository, string firstName)
        {
            return TypedResults.Ok(repository.Get(firstName));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddStudent(IRepository<Student> repository, Student student)
        {
            if(student == null)
            {
                return Results.NotFound();
            }
            repository.Add(student);
            return TypedResults.Created($"/{student.FirstName}", student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateStudent(IRepository<Student> repository, string firstName, Student student)
        {
            return TypedResults.Ok(repository.Update(firstName, student));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository<Student> repository, string firstName)
        {
            return TypedResults.Ok(repository.Delete(firstName));
        }



    }
}
