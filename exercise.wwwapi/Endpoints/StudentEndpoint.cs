using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using exercise.wwwapi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var students = app.MapGroup("students");

            students.MapGet("/", GetAll);
            students.MapGet("/{firstname}", GetOne);
            students.MapPost("/", AddStudent);
            students.MapDelete("/{firstname}", DeleteStudent);
            students.MapPut("/{firstname}", UpdateStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IRepository<Student> repository)
        {
            var student = repository.GetAll();
            return Results.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetOne(IRepository<Student> repository, string firstname)
        {
            var student = repository.GetOne(firstname);
            return Results.Ok(student);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddStudent(IRepository<Student> repository, StudentPost model)
        {
            Student student = new Student()
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            repository.Add(student);

            return Results.Created($"https://localhost:7010/pets/{student.FirstName}", student);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IRepository<Student> repository, string firstname)
        {
            try
            {
                var model = repository.GetOne(firstname);
                if (repository.Delete(firstname)) return Results.Ok(new { When = DateTime.Now, Status = "Deleted", FirstName = model.FirstName, LastName = model.LastName });
                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateStudent(IRepository<Student> repository, string firstname, StudentPut model)
        {
            try
            {
                var target = repository.GetOne(firstname);
                if (target == null) return Results.NotFound();
                if (model.FirstName != null) target.FirstName = model.FirstName;
                if (model.LastName != null) target.LastName = model.LastName;
                return Results.Ok(target);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

    }
}
