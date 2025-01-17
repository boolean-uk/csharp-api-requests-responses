using System.Security.Cryptography.X509Certificates;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;
using exercise.wwwapi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var students = app.MapGroup("students");

            students.MapPost("/", StudentCreate);
            students.MapGet("/{firstName}", StudentGet);
            students.MapGet("/", StudentGetAll);
            students.MapPut("/{firstName}", StudentUpdate);
            students.MapDelete("/{firstName}", StudentDelete);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> StudentGetAll(IRepository repository)
        {
            var students = repository.GetStudents();
            return Results.Ok(students);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> StudentGet(IRepository repository, string firstName)
        {
            var student = repository.GetStudent(firstName);
            return Results.Ok(student);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> StudentCreate(IRepository repository, StudentPut entity)

        {
            var newStudent = new Student();
            newStudent.FirstName = entity.FirstName;
            newStudent.LastName = entity.LastName;

            repository.CreateStudent(newStudent);
            return Results.Ok(repository.GetStudent(entity.FirstName));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> StudentUpdate(IRepository repository, string firstName, StudentPut entity)

        {
            try
            {
                repository.UpdateStudent(firstName, entity.FirstName, entity.LastName);
                return Results.Ok(repository.GetStudent(entity.FirstName));
            }
            catch (Exception ex)
            {
                {
                    return TypedResults.Problem(ex.Message);
                }

            }

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> StudentDelete(IRepository repository, string firstName)

        {
            try
            {
                if (repository.GetStudent(firstName) == null)
                {
                    repository.DeleteStudent(firstName);
                    return Results.Ok(repository.GetStudents());
                }
                return Results.NotFound();
            }
            catch (Exception e)
            {
                return Results.BadRequest();
            }

        }
    }
}   
