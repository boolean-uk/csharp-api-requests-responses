using System.Diagnostics.Eventing.Reader;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {

        public static void ConfigureStudents( this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapPost("/", AddStudent);
            students.MapGet("/", GetStudents);
            students.MapGet("/{firstname}", GetStudentByFirstName);
            students.MapPut("/{firstname}", UpdateStudent);
            students.MapDelete("/{firstname}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult>AddStudent(IRepository repo, Student student)
        {
            try
            {
                repo.Add(student);
                return Results.Ok();
            }
            catch (Exception ex) {
                return TypedResults.NotFound(ex);
            }
            
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repo)
        {
            try
            {
                var students = repo.GetAll();
                return TypedResults.Ok(students);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult>GetStudentByFirstName(IRepository repo, string firstname)
        {
            
                var student = repo.GetStudentByFirstName(firstname);
                if (student != null)
                {
                return TypedResults.Ok(student);
            }
                else
            {
                return TypedResults.NotFound();
            }
            
            }

        [ProducesResponseType (StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateStudent(IRepository repo, string firstname, string newFirstName, string newLastName)
        {
            
            var student = repo.UpdateStudentByFirstName(firstname, newFirstName, newLastName);
            
            if (student != null)
            {
                return TypedResults.Ok(student);
            }
            else
            {
                return TypedResults.NotFound();
            }

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IRepository repo, string firstname)
        {

            var student = repo.DeleteStudent(firstname);
            if (student != null)
            {
                return TypedResults.Ok(student);
            }
            else
            {
                return TypedResults.NotFound();
            }

        }
    }
    }

