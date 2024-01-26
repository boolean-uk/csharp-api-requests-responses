
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var studentGroup = app.MapGroup("students");

            studentGroup.MapGet("/", GetStudents);
            studentGroup.MapPost("/", AddStudent);
            studentGroup.MapGet("/{firstname}", GetStudentByFirstName);
            studentGroup.MapPut("/{firstname}", UpdateStudent);
            studentGroup.MapDelete("/{firstname}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public async static Task<IResult> GetStudents(IRepository repository)
        {
            return TypedResults.Ok(repository.GetStudents());
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async static Task<IResult> AddStudent(IRepository repository, Student student)
        {
            var newStudent = new Student()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
            };
            {
                repository.AddStudent(newStudent);
                return TypedResults.Created($"{newStudent.FirstName}");
            }
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async static Task<IResult> GetStudentByFirstName(IRepository repository, string firstName)
        {
            var result = repository.GetStudentByFirstName(firstName);
            if (result != null) { 
                return TypedResults.Ok(result);
            } else return TypedResults.NotFound();
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async static Task<IResult> UpdateStudent(IRepository repository, string firstName, StudentPut studentPut)
        {
            return TypedResults.Ok(repository.UpdateStudent(firstName, studentPut));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async static Task<IResult> DeleteStudent(IRepository repository, string firstName)
        {
            return TypedResults.Ok(repository.DeleteStudent(firstName));
        }
    }
         
}
