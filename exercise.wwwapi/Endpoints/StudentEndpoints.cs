using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoints
    {

        public static void ConfigureStudent(this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapGet("/students", GetStudents);
            students.MapGet("/students/{fristName}", GetAStudent);
            students.MapPost("/students", PostStudent);
            students.MapDelete("/students/{firstname}", DeleteStudent);
            students.MapPut("/students/{firstname}", UpdateStudent);
        }
        
        private static IResult UpdateStudent(IStudentRepository repo, string name, string newFirst, string newLast)
        {
            Student student = repo.UpdateStudent(name, newFirst, newLast);
            return TypedResults.Ok(student);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        private static IResult DeleteStudent(string name) 
        {
            StudentCollection.Delete(name);

            return TypedResults.Ok();
        }


        private static IResult PostStudent(IStudentRepository repo, string firstName, string lastName)
        {
            Student student = repo.CreateStudent(firstName, lastName);
            return TypedResults.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static IResult GetStudents(IStudentRepository repo)
        {
            return TypedResults.Ok(repo.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static IResult GetAStudent(IStudentRepository repo, string name)
        {
            return TypedResults.Ok(repo.GetAStudent(name));
        }
        
    }
}
