using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var studentGroup = app.MapGroup("students");

            studentGroup.MapGet("/", GetStudents);
            studentGroup.MapPost("/", AddStudent);
            studentGroup.MapGet("/{firstName}", GetStudent);
            studentGroup.MapPut("/{firstName}", UpdateStudent);
            studentGroup.MapDelete("/delete/{firstName}", DeleteStudent);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(StudentCollection studentCollection)
        {
            return TypedResults.Ok(studentCollection.getAll());
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddStudent(StudentCollection studentCollection, Student student)
        {   
            var newStudent = new Student() {FirstName=student.FirstName, LastName=student.LastName };
            studentCollection.Add(newStudent);
            return TypedResults.Created("/", newStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudent(StudentCollection studentCollection, string firstName)
        {
            return TypedResults.Ok(studentCollection.GetStudent(firstName));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]

        public static async Task<IResult> UpdateStudent(StudentCollection studentCollection, string firstName)
        {
            return TypedResults.Ok(studentCollection.UpdateStudent(firstName));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]

        public static async Task<IResult> DeleteStudent(StudentCollection studentCollection, string firstName)
        {
            return TypedResults.Ok(studentCollection.DeleteStudent(firstName));
        }
    }
}
