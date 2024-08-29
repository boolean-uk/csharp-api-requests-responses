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
            //students.MapGet("/", GetStudents);
            //students.MapGet("/", GetStudents);
            //students.MapGet("/", GetStudents);
        }

        [HttpPost]
        [Route("")]
        public static IResult AddStudent(IStudentRepository repository, Student student)
        {
            return TypedResults.Ok(repository.AddStudent(student));
        }

        [HttpGet]
        [Route("")]
        public static IResult GetStudents(IStudentRepository repository)
        {
            return TypedResults.Ok(repository.GetStudents());
        }
    }
}
