using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var students = app.MapGroup("Students");

            students.MapGet("/", GetStudents);
            students.MapGet("/{LastName}", GetStudent);
            students.MapPost("/", AddStudent);
            students.MapPut("/{LastName}", UpdateStudent);
            students.MapDelete("/{LastName}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IStudentRepository repository)
        {
            var students = repository.GetStudents();
            return Results.Ok(students);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetStudent(IStudentRepository repository, string LastName)
        {
            var student = repository.GetStudent(LastName);
            if (student == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(student);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddStudent(IStudentRepository repository, Student student)
        {
            Student newStudent = new Student()
            {
                LastName = student.LastName,
                FirstName = student.FirstName,
            };

            repository.AddStudent(newStudent);
            return Results.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateStudent(IStudentRepository repository, string LastName, Student student)
        {
            try
            {
                var existingStudent = repository.GetStudent(LastName);
                if (existingStudent == null)
                {
                    return Results.NotFound();
                }

                var updatedStudent = repository.UpdateStudent(LastName, student);
                if (updatedStudent == null)
                {
                    return Results.BadRequest();
                }
                return Results.Ok(new
                {
                    when = DateTime.Now,
                    status = "Updated",
                    oldStudent = existingStudent,
                    updatedStudent = updatedStudent
                });
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> DeleteStudent(IStudentRepository repository, string LastName)
        {
            try
            {
                var studentToDelete = repository.GetStudent(LastName);
                if (repository.Delete(LastName)) return Results.Ok(new { when = DateTime.Now, status = "Deleted", Name = studentToDelete.LastName });
                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
