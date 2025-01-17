using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using exercise.wwwapi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var students = app.MapGroup("students");

            students.MapGet("/", GetStudents);
            students.MapGet("/{firstName}", GetStudent);
            students.MapPut("/{firstName}", UpdateStudent);
            students.MapPost("/", AddStudent);
            students.MapDelete("/{firstName}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var students = repository.GetStudents();
            return Results.Ok(students);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudent(IRepository repository, string firstName)
        {
            var student = repository.GetStudent(firstName);
            return Results.Ok(student);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddStudent(IRepository repository, StudentPost model)
        {
            Student student = new Student()
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            repository.AddStudent(student);

            return Results.Created("https://localhost:7068/students", student);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> DeleteStudent(IRepository repository, string firstName)
        {
            try
            {
                var model = repository.GetStudent(firstName);
                if (repository.DeleteStudent(firstName)) return Results.Ok(new { When = DateTime.Now, Status = "Deleted", FirstName = model.FirstName, LastName = model.LastName});
                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateStudent(IRepository repository, string firstName, StudentPut model)
        {
            var target = repository.GetStudent(firstName);
            if(target == null) return TypedResults.NotFound();
            if(model.firstName != null) target.FirstName = model.firstName;
            if(model.lastName != null) target.LastName = model.lastName;
            return TypedResults.Created($"https://localhost:7068/students/{firstName}",target);
        }
    }
}

