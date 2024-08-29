using Microsoft.AspNetCore.Mvc;
using exercise.wwwapi.Models;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http.HttpResults;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {

        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var students = app.MapGroup("Students");
            students.MapGet("/getAll", getStudents);
            students.MapGet("/get/{name}", getAStudent);
            students.MapPost("/create", createAStudent);
            students.MapPut("/edit/{name}", editAStudent);
            students.MapDelete("/delete/{name}", deleteAStudent);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult getStudents(IRepository<Student> students)
        {
            var currentStudents = students.getAll();
            return TypedResults.Ok(currentStudents);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult getAStudent(IRepository<Student> students, string name)
        {
            var student = students.getElementByName(name);
            return TypedResults.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult createAStudent(IRepository<Student> students, [FromBody] Student student)
        {
            students.createElement(student);
            return TypedResults.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult editAStudent(IRepository<Student> students, string name, [FromBody] Student student)
        {
            students.updateElement(student);
            return TypedResults.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult deleteAStudent(IRepository<Student> students,string name)
        {
            
            students.deleteElement(name);
            return TypedResults.Ok(students.getElementByName(name));
        }



    }

}

