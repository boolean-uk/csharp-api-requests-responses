using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var studentGroup = app.MapGroup("students");
            studentGroup.MapGet("/", GetAllStudents);
            studentGroup.MapGet("/{firstName}", GetStudentByFirstname);
            studentGroup.MapPost("/", CreateStudent);
            studentGroup.MapPut("/{firstName}", UpdateStudentByFirstname);
            studentGroup.MapDelete("/{firstName}", DeleteStudentByFirstname);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllStudents(IRepository<Student> r)
        {
            return TypedResults.Ok(r.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateStudent(IRepository<Student> r, [FromBody] Student s)
        {
            if (s == null) return TypedResults.BadRequest();
            return TypedResults.Created(" ", r.Create(s));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetStudentByFirstname(IRepository<Student> r, string firstname)
        {
            if (firstname == null) return TypedResults.BadRequest();
            Student res = r.GetByName(firstname);
            if (res == null) return TypedResults.NotFound();
            return TypedResults.Ok(res);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateStudentByFirstname(IRepository<Student> r, string firstName, [FromBody] Student updateStudent)
        {
            if (firstName == null) return TypedResults.BadRequest();
            Student result = r.Update(firstName, updateStudent);
            if (result == null) return TypedResults.NotFound();
            return TypedResults.Created(" ", result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudentByFirstname(IRepository<Student> r, string firstName)
        {
            if (firstName == null) return TypedResults.BadRequest();
            Student result = r.Delete(firstName);
            if (result == null) return TypedResults.NotFound();
            return TypedResults.Created(" ", result);
        }
    }
}
