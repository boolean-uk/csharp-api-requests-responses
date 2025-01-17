using System.Runtime.CompilerServices;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentsEndpoint
    {
        public static void ConfigureStudentsEndpoint(this WebApplication app)
        {
            var students = app.MapGroup("students");

            students.MapGet("/", GetAllStudents);
            students.MapPost("/", CreateStudent);
            students.MapGet("/{firstName}", GetSingleStudent);
            students.MapPut("/{firstName}", EditSingleStudent);
            students.MapDelete("/{firstName}", DeleteSingleStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetAllStudents(IRepository repository)
        {
            return Results.Ok(repository.GetStudents());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        private static async Task<IResult> CreateStudent(IRepository repository, Student model)
        {
            Student student = new Student()
                {
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            repository.CreateStudent(student);
            return Results.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetSingleStudent(IRepository repository, string firstname)
        {
            return Results.Ok(repository.GetStudent(firstname));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> EditSingleStudent(IRepository repository, Student updatedStudent, string firstname)
        {
            Student student = repository.GetStudent(firstname);
            student.FirstName = updatedStudent.FirstName;
            student.LastName = updatedStudent.LastName;
            return Results.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> DeleteSingleStudent(IRepository repository, string firstname)
        {
            try
            {
                Student student = repository.GetStudent(firstname);
                if (repository.DeleteStudent(firstname) != null)
                {
                    return Results.Ok(student);
                }
                return Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
