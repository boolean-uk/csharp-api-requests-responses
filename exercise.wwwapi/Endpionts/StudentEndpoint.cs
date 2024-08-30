using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace exercise.wwwapi.Endpionts
{
    public static class StudentEndpoint
    {
        public static void CofigureStudentEnpoint(this WebApplication application)
        {
            var studentGroup = application.MapGroup("students");
            studentGroup.MapGet("/", GetStudents);
            studentGroup.MapGet("/{firstName}", GetAStudent);
            studentGroup.MapPost("/", AddStudent);
            studentGroup.MapPut("/{firstname}", UppdateStudent);
            studentGroup.MapDelete("/{firstname}", DeleteStudent);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetStudents(IStudentRepository repository)
        {
            return TypedResults.Ok(repository.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAStudent(IStudentRepository repository, string firstName)
        {
            return TypedResults.Ok(repository.GetByName(firstName));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult AddStudent(IStudentRepository repository, string firstName, string lastName)
        {
            return TypedResults.Created(repository.AddStudent(firstName, lastName).ToString());

        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UppdateStudent(IStudentRepository repository, string firstName,string newFirstname, string newLastName)
        {
            return TypedResults.Ok(repository.UppdateStudent(firstName, newFirstname, newLastName));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteStudent(IStudentRepository repository, string firstName) 
        {
            return TypedResults.Ok(repository.DeleteStudent(firstName));
        }


    }
}
