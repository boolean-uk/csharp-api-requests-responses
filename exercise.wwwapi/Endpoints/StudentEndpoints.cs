
using System.Xml.Linq;
using exercise.wwwapi.Extensions;
using exercise.wwwapi.Repositories.Interfaces;
using exercise.wwwapi.Views;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoints
    {
        public static void ConfigureStudentEndPoints(this WebApplication app)
        {
            var student = app.MapGroup("students");
            student.MapGet("/", GetStudents);
            student.MapPost("/", CreateStudent);
            student.MapGet("/{name}", GetStudent);
            student.MapPut("/{name}", UpdateStudent);
            student.MapDelete("/{name}", DeleteStudent);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IStudentRepository repo, string name)
        {
            var stud = repo.DeleteStudent(name);
            if (stud != null)
                return TypedResults.Ok(stud);
            return TypedResults.NotFound(false);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetStudent(IStudentRepository repo, string name)
        {
            var stud = repo.GetStudent(name);
            if (stud != null)
                return TypedResults.Ok(stud);
            return TypedResults.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateStudent(HttpContext context, IStudentRepository repo, string name, StudentView dto)
        {
            var stud = repo.UpdateStudent(name, dto);
            if (stud != null)
                return TypedResults.Created(context.Get_endpointUrl(stud.FirstName), stud);
            return TypedResults.BadRequest();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateStudent(HttpContext context, IStudentRepository repo, StudentView dto)
        {
            var stud = repo.AddStudent(dto);
            if (stud != null)
                return TypedResults.Created(context.Get_endpointUrl(stud.FirstName),stud);
            return TypedResults.BadRequest();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IStudentRepository repo)
        {
            return TypedResults.Ok(repo.GetStudents());
        }
    }
}
