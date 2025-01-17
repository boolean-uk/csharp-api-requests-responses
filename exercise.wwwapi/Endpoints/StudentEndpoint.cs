using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var student = app.MapGroup("student");

            student.MapGet("/", GetStudents);
            student.MapGet("/{firstName}", GetStudent);
            student.MapPost("/", AddStudent);
            student.MapDelete("/{firstName}", DeleteStudent);
            student.MapPut("/{firstName}", UpdateStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            var student = repository.GetStudents();
            return Results.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> GetStudent(IRepository repository, [FromRoute] string firstName)
        {
            var student = repository.GetStudent(firstName);
            if (student == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddStudent(IRepository repository, Student model)
        {
            Student student = new Student()
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            repository.AddStudent(student);

            return Results.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> DeleteStudent(IRepository repository, [FromRoute] string firstName)
        {
            try
            {
                var model = repository.GetStudent(firstName);
                if (repository.DeleteStudent(firstName))
                {
                    return Results.Ok(model);
                }
                else
                {
                    return TypedResults.NotFound();
                }
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> UpdateStudent(IRepository repository, [FromRoute] string firstName, Student model)
        {
            var student = new Student()
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            var updatedStudent = repository.UpdateStudent(firstName, student);
            return Results.Ok(updatedStudent);
        }

    }
}
