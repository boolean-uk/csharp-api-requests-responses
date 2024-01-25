using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentsEndpoint
    {
        public static void ConfigureStudentsEndpoint(this WebApplication app)
        {
            var studentsGroup = app.MapGroup("students");

            studentsGroup.MapGet("/", GetStudents);
            studentsGroup.MapPost("/", AddStudents);
            studentsGroup.MapGet("/{firstName}", GetStudent);
            studentsGroup.MapPut("/{firstName}", UpdateStudent);
            studentsGroup.MapDelete("/{firstName}", DeleteStudent);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IStudentRepository repository)
        {
            return TypedResults.Ok(repository.Get());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddStudents(IStudentRepository repository, Student student)
        {
            return TypedResults.Ok(repository.Add(student));
     
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudent(IStudentRepository repository, string firstName)
        {
            return TypedResults.Ok(repository.Get(firstName));
        }
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public static async Task<IResult> UpdateStudent(IStudentRepository repository, string firstName, Student student)
        {
            return TypedResults.Ok(repository.Update(firstName, student));
        }
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public static async Task<IResult> DeleteStudent(IStudentRepository repository, string firstName)
        {
            return TypedResults.Ok(repository.Delete(firstName));
        }
    }
}
