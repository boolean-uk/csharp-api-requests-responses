using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoints
    {
        // Create extended method:

        public static void ConfigureStudentEndpoint(this WebApplication app) {

            // Create route
            var studentGroup = app.MapGroup("students");
            studentGroup.MapPost("/", CreateStudent);   //MapPost -> createStudent
            studentGroup.MapGet("/", GetStudent);   //MapGet -> GetStudent
            studentGroup.MapGet("/{firstName}", GetAStudent);
            studentGroup.MapPut("/{firstName}", UpdateStudent);
            studentGroup.MapDelete("/{firstName}", DeleteAStudent);
        }

        // Construct MapPost CreateStudent
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateStudent(IRepository repository, StudentPost inputStudent)   // GetCars uses inpendecy injections?
        {
            if (inputStudent == null)
            {
                return Results.NotFound();
            }
            var newStudent = new Student() { FirstName = inputStudent.FirstName, LastName = inputStudent.LastName };
            repository.AddStudent(newStudent);

            return TypedResults.Created($"/{newStudent.FirstName}, {newStudent.LastName}",newStudent);
        }

        // Construct MapGet GetStudent
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudent(IRepository repository)   // GetCars uses inpendecy injections?
        {
            var studentList = repository.GetStudents();
            return studentList != null ? TypedResults.Ok(studentList) : Results.NotFound();
        }

        // Construct MapGet GetAStudent
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAStudent(IRepository repository,string firstName)   // GetCars uses inpendecy injections?
        {
            var fillteredStudent = repository.GetStudents().FirstOrDefault(student => student.FirstName == firstName);

            return fillteredStudent != null ? TypedResults.Ok(fillteredStudent) : Results.NotFound();
        }

        // Construct MapPut UpdatedStudent
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateStudent(IRepository repository, string firstName, [FromBody] StudentPost updatedStudent)   // GetCars uses inpendecy injections?
        {
            var fillteredStudent = repository.GetStudents().FirstOrDefault(student => student.FirstName == firstName);
            if (fillteredStudent != null)
            {
                fillteredStudent.LastName = updatedStudent.LastName;
                fillteredStudent.FirstName = updatedStudent.FirstName;
                return  TypedResults.Created($"/{updatedStudent.FirstName}", updatedStudent);   // This printout both first name and last name
            }

           return TypedResults.NotFound();
        }

        // Construct MapDelete DeleteAStudent
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteAStudent(IRepository repository, string firstName)   // GetCars uses inpendecy injections?
        {
            var fillteredStudent = repository.GetStudents().FirstOrDefault(student => student.FirstName == firstName);
            if (fillteredStudent != null)
            {
                return TypedResults.Ok(repository.Remove(fillteredStudent));
            }

            return TypedResults.NotFound();
        }





    }
}
