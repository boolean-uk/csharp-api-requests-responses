using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    [ApiController]
    [Route("students")]
    public static class StudentController
    {
        public static void ConfigureStudentController(this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapGet("/", GetStudents);
            students.MapPost("/", AddStudent);
            students.MapGet("/{FirstName}", GetStudent);
            students.MapPut("/", UpdateStudent);
            students.MapDelete("/", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static IResult DeleteStudent(IStudentRepository repository, string FirstName)
        {
            var result = repository.DeleteStudent(FirstName);
            return result == null ? TypedResults.NotFound(result) : TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static IResult UpdateStudent(IStudentRepository repository, string FirstName, Student student)
        {
            var result = repository.UpdateStudent(FirstName, student);
            return result == null ? TypedResults.NotFound(result) : TypedResults.Created();
        }

        //[HttpGet]
        //[]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult GetStudent(IStudentRepository repository, string FirstName)
        {
            var result = repository.GetStudent(FirstName);
            return result == null ? TypedResults.NotFound(result) : TypedResults.Ok(result);
        }

        //[HttpPost]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult AddStudent(IStudentRepository repository, Student student)
        {
            var result = repository.AddStudent(student);
            return result == null ? TypedResults.BadRequest(result) : TypedResults.Ok(result);
        }

        //[HttpGet]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetStudents(IStudentRepository repository)
        {
            return TypedResults.Ok(repository.GetStudents());
        }
    }
}
