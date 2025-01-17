using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoints
    {
        public static void ConfigureStudentEndpoints(this WebApplication app)
        {

            var studentGroup = app.MapGroup("students");
            studentGroup.MapPost("/", AddStudent);
            studentGroup.MapGet("/", GetAllStudents);
            studentGroup.MapGet("/{firstName}", GetStudent);
            studentGroup.MapPut("/{firstName}", UpdateStudent);
            studentGroup.MapDelete("/{firstName}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult AddStudent(IStudentRepository repository, Student student)
        {
            repository.Create(student);

            return TypedResults.Created($"/students/{student.FirstName}", student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllStudents(IStudentRepository repository)
        {
            var students = repository.GetAll();

            return TypedResults.Ok(students);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetStudent(IStudentRepository repository, string firstName)
        {
            var student = repository.Get(firstName);

            return TypedResults.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UpdateStudent(IStudentRepository repository, string firstName, Student student)
        {
            var updatedStudent = repository.Update(firstName, student);

            return TypedResults.Created($"/students/{firstName}", updatedStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteStudent(IStudentRepository repository, string firstName)
        {
            var deletedStudent = repository.Delete(firstName);

            return TypedResults.Ok(deletedStudent);
        }



    }
}
