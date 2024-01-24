using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var studentGroup = app.MapGroup("students"); 
            
            studentGroup.MapGet("/", GetStudents);
            studentGroup.MapPost("/", AddStudent);
            studentGroup.MapGet("/{firstName}", GetStudent);
            studentGroup.MapPut("/{firstName}", UpdateStudent);
            studentGroup.MapDelete("/{firstName}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            return TypedResults.Ok(repository.GetStudents());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddStudent(IRepository repository, Student model)
        {
            var studentToAdd = new Student() {FirstName = model.FirstName, LastName = model.LastName};
            repository.AddStudent(studentToAdd);
            return TypedResults.Ok(studentToAdd);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudent(IRepository repository,  string studentName)
        {
            var student = repository.GetStudent(studentName);
            return TypedResults.Ok(student);
        }        
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateStudent(IRepository repository,  string firstName, string updatedFirstName)
        {
            var student = repository.UpdateStudent(firstName, updatedFirstName);
            return TypedResults.Ok(student);
        }

        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository repository,  string firstName, string lastName)
        {
            var student = repository.DeleteStudent(firstName, lastName);
            return TypedResults.Ok(student);
        }




    }
}
