using exercise.wwwapi.Core.Models;
using exercise.wwwapi.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Core.Endpoints
{
    public static class StudentsEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var students = app.MapGroup("students");

            students.MapGet("/", GetStudents);
            students.MapGet("/{firstName}", GetSingleStudent);
            students.MapPost("/", AddStudent);
            students.MapPut("/{firstName}", UpdateStudent);
            students.MapDelete("/{firstName}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IStudentRepository repository)
        {
            var students = repository.GetStudents();
            return Results.Ok(students);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetSingleStudent(IStudentRepository repository, string firstName)
        {
            var student = repository.GetSingleStudent(firstName);
            return Results.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddStudent(IStudentRepository repository, Student student)
        {
            var addedStudent = repository.AddStudent(student);
            return Results.Created($"https://localhost:7068/students/{addedStudent.FirstName}", addedStudent);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateStudent(IStudentRepository repository, string firstName, Student updatedStudent)
        {
            var result = repository.UpdateStudent(firstName, updatedStudent);
            return Results.Created($"https://localhost:7068/students/{updatedStudent.FirstName}", updatedStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IStudentRepository repository, string firstName)
        {
            var deletedStudent = repository.DeleteStudent(firstName);
 
            return Results.Ok(deletedStudent);
        }
    }
}
