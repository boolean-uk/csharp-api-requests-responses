using exercise.wwwapi.DTO;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;
using exercise.wwwapi.Responses;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoints
    {
        public static void ConfigureStudentEndpoints(this WebApplication app)
        {

            var students = app.MapGroup("students");

            students.MapGet("/", GetStudents);
            students.MapGet("/{id}", GetStudentById);
            students.MapPost("/", AddStudent);
            students.MapPut("/{firstName}", UpdateStudent);
            students.MapDelete("/{firstName}", DeleteStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository<Student> repository)
        {
            var students = repository.GetAll();
            var studentResponses = students.Select(student => new StudentResponse
            {
                FirstName = student.FirstName,
                LastName = student.LastName
            });
            return Results.Ok(studentResponses);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudentById(IRepository<Student> repository, int id)
        {
            var student = repository.GetById(id);
            if (student == null)
            {
                return Results.NotFound();
            }
            var response = new StudentResponse
            {
                FirstName = student.FirstName,
                LastName = student.LastName
            };
            return Results.Ok(response);
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddStudent(IRepository<Student> repository, StudentDto student)
        {
            var newStudent = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName
            };
            repository.Add(newStudent);
            var response = new StudentResponse
            {
                FirstName = newStudent.FirstName,
                LastName = newStudent.LastName
            };
            return Results.Ok(response);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateStudent(IRepository<Student> repository, string firstName, StudentDto student)
        {

            //Ideally we have a service layer (?) where we can find the proper ID and update the right student. Currently we double up some logic to keep our interface generic wich is not ideal.
            var studentToUpdate = repository.GetAll().FirstOrDefault(s => s.FirstName == firstName);
            studentToUpdate.FirstName = student.FirstName;
            studentToUpdate.LastName = student.LastName;

            repository.Update(studentToUpdate);
            var response = new StudentResponse
            {
                FirstName = studentToUpdate.FirstName,
                LastName = studentToUpdate.LastName
            };
            return Results.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IRepository<Student> repository, string firstName)
        {
            int id = repository.GetAll().FirstOrDefault(s => s.FirstName == firstName).Id;
            var result = repository.Delete(id);
            if (!result)
            {
                return Results.NotFound();
            }
            return Results.Ok();
        }
    }
}
