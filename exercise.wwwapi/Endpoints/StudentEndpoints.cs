using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoints
    {
        public static void ConfigureStudentEndpoints(this WebApplication app)
        {
            var StudentGroup = app.MapGroup("students");

            StudentGroup.MapPost("/add", AddStudent);
            StudentGroup.MapGet("/all", GetAllStudents);
            StudentGroup.MapGet("/get", GetStudent);
            StudentGroup.MapPut("/update", UpdateStudent);
            StudentGroup.MapDelete("/delete", DeleteStudent);

        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddStudent(IRepository repository, Student student)
        {
            var newStudent = new Student() { FirstName = student.FirstName, LastName = student.LastName};
            return TypedResults.Created($"New student: ", newStudent);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllStudents(IRepository repository)
        {
            return TypedResults.Ok(repository.GetAllStudents());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudent(IRepository repository, string firstName)
        {
            return TypedResults.Ok(repository.GetStudent(firstName));
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateStudent(IRepository repository, string firstName, Student student)
        {
            return TypedResults.Ok(repository.UpdateStudent(firstName, student));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository repository, string firstName)
        {
            return TypedResults.Ok(repository.DeleteStudent(firstName));
        }
    }
}
