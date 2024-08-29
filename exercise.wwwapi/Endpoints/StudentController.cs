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
            students.MapGet("/{id}", GetStudent);
            students.MapPut("/", UpdateStudent);
            students.MapDelete("/", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        private static IResult DeleteStudent(IStudentRepository repository, int id)
        {
            return TypedResults.Ok(repository.DeleteStudent(id));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        private static IResult UpdateStudent(IStudentRepository repository, Student student)
        {
            return TypedResults.Ok(repository.UpdateStudent(student));
        }

        //[HttpGet]
        //[]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static IResult GetStudent(IStudentRepository repository, int id)
        {
            return TypedResults.Ok(repository.GetStudent(id));
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
