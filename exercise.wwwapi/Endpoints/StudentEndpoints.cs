using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoints
    {
        public static void ConfigureStudentEndpoint(this WebApplication app) 
        {
            var studentGroup = app.MapGroup("students");
            studentGroup.MapPost("/", CreateStudent);
            studentGroup.MapGet("/", GetAllStudents);
            studentGroup.MapGet("/{firstName}", GetStudent);
            studentGroup.MapPut("/{firstName}", UpdateStudent);
            studentGroup.MapDelete("/{FirstName}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateStudent(IRepository repository, Student student)
        {
            Student createdStudent = repository.CreateStudent(student);            
            return TypedResults.Created("students/",createdStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllStudents(IRepository repository) 
        {
            return TypedResults.Ok(repository.GetAllStudents());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudent(IRepository repository, string firstName) 
        {
            Student student = repository.GetStudent(firstName);
            return TypedResults.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateStudent(IRepository repository, string firstName, Student student) 
        {
            Student retrievedStudent = repository.UpdateStudent(firstName, student);
            return TypedResults.Created("students/{firstName}", retrievedStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository repository, string FirstName) 
        {
            return TypedResults.Ok(repository.DeleteStudent(FirstName));
        }

    }
}
