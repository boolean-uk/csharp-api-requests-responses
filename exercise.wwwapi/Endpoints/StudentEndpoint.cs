using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var studentGroup = app.MapGroup("students");

            studentGroup.MapGet("/", GetStudents);
            studentGroup.MapGet("/{firstName}", GetStudent);
            studentGroup.MapPost("/", CreateStudent);
            studentGroup.MapPut("/{firstName}", UpdateStudent);
            studentGroup.MapDelete("/", DeleteStudent);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IStudentRepository repository)
        {
            return TypedResults.Ok(repository.GetStudents());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateStudent(IStudentRepository repository, Student student)
        {
            if (!student.FirstName.Any() || !student.LastName.Any())
            {
                return Results.BadRequest("Missing some student data");
            }
            repository.AddStudent(student);
            return TypedResults.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetStudent(IStudentRepository repository, string firstName)
        {
            var student = repository.GetStudents().First(s => s.FirstName.ToLower() == firstName.ToLower());

            if (student != null) return TypedResults.Ok(student);
            return Results.NotFound($"Student: {firstName} not found!");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateStudent(IStudentRepository repository, string firstName, Student newStudent)
        {
            var student = repository.GetStudents().First(s => s.FirstName.ToLower() == firstName.ToLower());

            if (student == null) return Results.NotFound($"Student: {firstName} not found!");
            if (!student.FirstName.Any() || !student.LastName.Any()) return Results.BadRequest("Missing some student data");

            student.Rename(newStudent.FirstName, newStudent.LastName);
            return TypedResults.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IStudentRepository repository, string firstName)
        {
            var student = repository.GetStudents().First(s => s.FirstName.ToLower() == firstName.ToLower());

            if (student == null) return Results.NotFound($"Student: {firstName} not found!");

            repository.DeleteStudent(student);
            return TypedResults.Ok(student);

        }
    }
}
