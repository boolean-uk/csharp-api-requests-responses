using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories.Interfaces;
using exercise.wwwapi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class ConfigureStudentEndpoints
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var counters = app.MapGroup("students");

            counters.MapGet("/", GetStudents);
            counters.MapGet("/{id}", GetStudent);
            counters.MapGet("/find/{name}", GetStudentByName);
            counters.MapPost("/", PostStudent);
            counters.MapPut("/{id}", PutStudent);
            counters.MapDelete("/{id}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IGenericRepository<Student> repository)
        {
            return TypedResults.Ok(repository.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetStudent(IGenericRepository<Student> repository, int id)
        {
            try
            {
                return TypedResults.Ok(repository.Get(id));
            }
            catch (ArgumentException ex)
            {
                return TypedResults.NotFound(new { ex.Message });
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetStudentByName(IGenericRepository<Student> repository, string name)
        {
            try
            {
                return TypedResults.Ok(repository.Get((student) => student.FirstName.ToLower() == name.ToLower() || student.LastName.ToLower() == name.ToLower()));
            }
            catch (ArgumentException ex)
            {
                return TypedResults.NotFound(new { ex.Message });
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> PostStudent(IGenericRepository<Student> repository, StudentPost entity)
        {
            Student student = repository.Add(new Student { FirstName = entity.FirstName, LastName = entity.LastName });
            return TypedResults.Created("", student);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> PutStudent(IGenericRepository<Student> repository, int id, StudentPut entity) 
        {
            Student student = repository.Update(id, new Student { FirstName = entity.FirstName, LastName = entity.LastName });
            return TypedResults.Created("", student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IGenericRepository<Student> repository, int id)
        {
            try
            {
                Student student = repository.Get(id);
                return TypedResults.Ok(new { Deleted = repository.Delete(id), Name = $"{student.FirstName} {student.LastName}" });
            }
            catch (ArgumentException ex)
            {
                return TypedResults.NotFound(new { ex.Message });
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
