using exercise.wwwapi.Data;
using exercise.wwwapi.Repository;
using exercise.wwwapi.Models;
using exercise.wwwapi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoints
    {
        public static void ConfigureStudentEndpoints(this WebApplication app ) 
        {
            var students = app.MapGroup("students");

            students.MapGet("/", GetAll);
            students.MapGet("/{firstname}", GetStudent);
            students.MapPost("/", AddStudent);
            students.MapDelete("/{firstname}", RemoveStudent);
            students.MapPut("/{firstname}", UpdateStudent);


        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IRepository<Student> rep)
        {
            var studs = rep.GetAll();
            return Results.Ok(rep.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetStudent(IRepository<Student>  rep, string firstname)
        {
            try
            {
                Student student = rep.GetEntity(firstname);

                if (student == null) return Results.NotFound();

                return Results.Ok(student);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddStudent(IRepository<Student> rep, PostStudent model)
        {
            try
            {
                Student student = new Student()
                {
                    FirstName = model.Firstname,
                    LastName = model.Lastname
                };

                rep.AddEntity(student);
                return Results.Ok(student);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
            
        }

        // Returns the deletetd student
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> RemoveStudent(IRepository<Student> rep, string firstname)
        {

            try
            {
                Student student = rep.RemoveEntity(firstname);

                if (student == null) return Results.NotFound();

                return Results.Ok(student);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateStudent(IRepository<Student> rep, string firstname, PutStudent model)
        {
            try
            {
                Student student = rep.GetEntity(firstname);

                if (student == null) return Results.NotFound();
                if (model.Firstname != null) student.FirstName = model.Firstname;
                if (model.Lastname != null) student.LastName = model.Lastname;

                return Results.Ok(student);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }


    }
}
