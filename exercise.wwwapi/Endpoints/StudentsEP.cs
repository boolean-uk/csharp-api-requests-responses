using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentsEP
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var students = app.MapGroup("students");

            students.MapGet("/", GetAllStudents);
            students.MapGet("/{firstName}", GetStudentByName);
            students.MapPost("/", AddStudent);
            students.MapPut("/{firstName}", UpdateStudent);
            students.MapDelete("/{firstName}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddStudent(IStudents students, Student student)
        {
            
            return TypedResults.Created($"/students/{student.FirstName}" , students.AddStudent(student));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllStudents(IStudents students)
        {
            return Results.Ok(students.GetStudents());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudentByName(IStudents students, string firstName)
        {
            return Results.Ok(students.GetStudent(firstName));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateStudent(IStudents students, string firstName, Student student)
        {
            return TypedResults.Created($"/students/{student.FirstName}" ,students.UpdateStudent(student, firstName));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IStudents students, string firstName)
        {
            return Results.Ok(students.DeleteStudent(firstName));
        }
    }
}
