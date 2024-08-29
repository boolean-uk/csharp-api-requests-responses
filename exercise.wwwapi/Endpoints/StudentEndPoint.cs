using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndPoint
    {
        private static StudentCollection studentCollection = new StudentCollection();
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapGet("/", GetAllStudents);
            students.MapGet("/{firstname}", GetAStudent);
            students.MapPost("/", PostStudent);
            students.MapPut("/{firstname}", UpdateStudent);
            students.MapDelete("/{firstname}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllStudents()
        {
            return TypedResults.Ok(studentCollection.getAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAStudent(string firstName)
        {
            Student student = studentCollection.getAll().FirstOrDefault(s => s.FirstName == firstName);
            if(student == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult PostStudent([Required] string firstname, [Required] string lastName)
        {
            Student student = new Student();
            student.FirstName = firstname;
            student.LastName = lastName;
            studentCollection.Add(student);
            return TypedResults.Created("", student);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UpdateStudent(string firstname, [Required] string newFirstName, [Required] string lastName)
        {
            Student student = studentCollection.getAll().FirstOrDefault(s => s.FirstName == firstname);
            if (student == null)
            {
                return TypedResults.NotFound();
            }

            student.FirstName = newFirstName;
            student.LastName = lastName;
            return TypedResults.Created("", student);
        }

        public static IResult DeleteStudent(string firstname)
        {
            Student student = studentCollection.getAll().FirstOrDefault(s => s.FirstName == firstname);
            if (student == null)
            {
                return TypedResults.NotFound();
            }
            studentCollection.Remove(student);
            return TypedResults.Ok(student);
        }


    }
}
