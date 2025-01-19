using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using exercise.wwwapi.Models;


namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var students = app.MapGroup("students");

            students.MapGet("/", GetAll);
            students.MapPost("/{firstName}", GetStudent);
            students.MapPost("/", AddStudent);
            students.MapDelete("/{firstName}", DeleteStudent);
            students.MapPut("/{firstName}", UpdateStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IRepository repository)
        {

            var students = repository.GetAll();
            return Results.Ok(students);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task <IResult>GetStudent(IRepository repository,string firstName)
        {

            var student = repository.GetStudent(firstName);
            if (student != null)
            {
                return TypedResults.Ok(student);
            }
            else
            {
                return TypedResults.NotFound();
            }

        }

        
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> AddStudent(IRepository repository, Student student)
        {

            if (student != null)
            {
                repository.Add(student);
                return TypedResults.Ok(student);
            }
            else
            {
                return TypedResults.NotFound();
            }


        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IRepository repository, string firstName)
        {

            var student = repository.DeleteStudent(firstName);
            if (student != null)
            {
                return TypedResults.Ok(student);
            }
            else
            {
                return TypedResults.NotFound();
            }

        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateStudent(IRepository repository, string firstName, string newFirstName, string newLastName)
        {

            var student = repository.UpdateStudent(firstName, newFirstName, newLastName);

            if (student != null)
            {
                return TypedResults.Ok(student);
            }
            else
            {
                return TypedResults.NotFound();
            }

        }



    }
}
