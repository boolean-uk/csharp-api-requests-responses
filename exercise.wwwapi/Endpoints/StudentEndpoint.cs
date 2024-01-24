using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var studentGroup = app.MapGroup("students");

            studentGroup.MapPost("/", AddStudent);

            studentGroup.MapGet("/", GetStudents);

            studentGroup.MapGet("/{Name}", GetStudent);

            studentGroup.MapPut("/{Name}", UpdateStudentName);

            studentGroup.MapDelete("/{Name}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            return TypedResults.Ok(repository.GetStudents());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudent(IRepository repository, string name)
        {
            var student = repository.GetStudent(name);

            if (student == null)
            {
                return TypedResults.NotFound($"Student with name {name} was not found");
            }

            return TypedResults.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddStudent(IRepository repository, Student student)
        {
            var newStudent = repository.AddStudent(student);
            return TypedResults.Created(newStudent.FirstName, newStudent);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateStudentName(IRepository repository, string name, Student student)
        {
            var updatedStudent = repository.UpdateStudentName(name, student);

            if (updatedStudent == null)
            {
                return TypedResults.NotFound($"Student with name {name} was not found");
            }

            return TypedResults.Created(updatedStudent.FirstName, updatedStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository repository, string name)
        {
            var deletedStudent = repository.DeleteStudent(name);

            if (deletedStudent == null)
            {
                return TypedResults.NotFound($"Student was not found");
            }

            return TypedResults.Ok(deletedStudent);
        }
    }
}
