using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentsEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapPost("/", CreateStudent);
            students.MapGet("/", GetAllStudents);
            students.MapGet("/{firstname}", GetStudent);
            students.MapPut("/{firstname}", UpdateStudent);
            students.MapDelete("/{firstname}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult CreateStudent(IStudentRepository studentRepository, Student student)
        {
            studentRepository.AddStudent(student);
            return TypedResults.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllStudents(IStudentRepository studentRepository)
        {
            //Payload<List<Student>> payload = new Payload<List<Student>>();
            //payload.data = studentRepository.GetAllStudents();
            return TypedResults.Ok(studentRepository.GetAllStudents());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetStudent(IStudentRepository studentRepository, string firstname)
        {
            return TypedResults.Ok(studentRepository.GetStudent(firstname));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UpdateStudent(IStudentRepository studentRepository, string firstname, Student student)
        {
            return TypedResults.Ok(studentRepository.UpdateStudent(firstname, student));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteStudent(IStudentRepository studentRepository, string firstname)
        {
            return TypedResults.Ok(studentRepository.DeleteStudent(firstname));
        }

    }
}
