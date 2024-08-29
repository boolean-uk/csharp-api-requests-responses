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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        private static IResult DeleteStudent(IStudentRepository repository, string FirstName)
        {
            return TypedResults.Ok(repository.DeleteStudent(FirstName));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        private static IResult UpdateStudent(IStudentRepository repository, string FirstName, Student student)
        {
            return TypedResults.Ok(repository.UpdateStudent(FirstName, student));
        }

        //[HttpGet]
        //[]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static IResult GetStudent(IStudentRepository repository, string FirstName)
        {
            return TypedResults.Ok(repository.GetStudent(FirstName));
        }

        //[HttpPost]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static IResult AddStudent(IStudentRepository repository, Student student)
        {
            return TypedResults.Ok(repository.AddStudent(student));
        }

        //[HttpGet]
        //[Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static IResult GetStudents(IStudentRepository repository)
        {
            return TypedResults.Ok(repository.GetStudents());
        }
    }
}
