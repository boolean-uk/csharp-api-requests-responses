using exercise.wwwapi.Interfaces;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoints
    {
        
        public static void ConfigureStudentEndpoints(this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapPost("", CreateStudent);
            students.MapGet("", GetAllStudents);
            students.MapGet("/{firstname}", GetAStudent);
            students.MapPut("/{firstname}", UpdateStudent);
            students.MapDelete("/{firstname}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static IResult CreateStudent(IStudentRepository studentRepository, Student student)
        {

            if (student == null)
            {
                return TypedResults.BadRequest();
            }

            studentRepository.AddStudent(student);

            return TypedResults.Created();
        }

        [ProducesResponseType(StatusCodes.Status200OK)] 
        private static IResult GetAllStudents(IStudentRepository studentRepository)
        {
           return TypedResults.Ok(studentRepository.GetAllStudents());

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static IResult GetAStudent(IStudentRepository studentRepository, string firstname)
        {
            Student student = studentRepository.GetAStudent(firstname);

            if (student == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static IResult UpdateStudent(IStudentRepository studentRepository, string firstname, Student newValues)
        {
            Student oldStudent = studentRepository.GetAStudent(firstname);
            
            if (oldStudent == null)
            {
                return TypedResults.NotFound();
            }

            if (newValues == null)
            {
                return TypedResults.BadRequest();
            }

            studentRepository.UpdateStudent(firstname, newValues);

            return TypedResults.Created();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        private static IResult DeleteStudent(IStudentRepository studentRepository, string firstname)
        {
            Student student = studentRepository.GetAStudent(firstname);

            if (student == null)
            {
                return TypedResults.NotFound();
            }

            studentRepository.DeleteStudent(student.FirstName);

            return TypedResults.Ok();
        }

    }
}
