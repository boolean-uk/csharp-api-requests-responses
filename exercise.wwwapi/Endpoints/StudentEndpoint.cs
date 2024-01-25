using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var studentGroup = app.MapGroup("students");

            studentGroup.MapPost("/", AddStudent);
            studentGroup.MapGet("/", GetStudents);
            studentGroup.MapGet("/{firstName}", GetStudent);
            studentGroup.MapPut("/{firstName}", UpdateStudent);
            studentGroup.MapDelete("/{firstName}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            return TypedResults.Ok(repository.GetStudents());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudent(IRepository repository, string firstName)
        {
            return TypedResults.Ok(repository.GetStudent(firstName));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddStudent(IRepository repository, Student student)
        {
            //validate
            if (student == null)
            {

            }
            var newStudent = new Student() { FirstName = student.FirstName, LastName = student.LastName };
            repository.AddStudent(newStudent);
            return TypedResults.Created($"/{newStudent.FirstName}", newStudent);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateStudent(IRepository repository, string firstName, Student student)
        {
            //validate
            if (student == null)
            {

            }   
            return TypedResults.Ok(repository.UpdateStudent(firstName, student));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository repository, string firstName)
        {
            var result = TypedResults.Ok(repository.GetStudent(firstName));
            repository.DeleteStudent(firstName);
            return result;
        }
    }
}
