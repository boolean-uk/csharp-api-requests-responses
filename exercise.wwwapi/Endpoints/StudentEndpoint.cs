using exercise.wwwapi.DTOs;
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

            studentGroup.MapGet("/", GetStudents);
            studentGroup.MapGet("/{id}", GetStudent);
            studentGroup.MapDelete("/{id}", DeleteStudent);
            studentGroup.MapPost("/", AddStudent);
            studentGroup.MapPut("/{id}", PutStudent);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetStudents(IRepository<Student> repository)
        {
            return TypedResults.Ok(repository.GetAll());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetStudent(IRepository<Student> repository, string id)
        {
            try
            {
                return TypedResults.Ok(repository.GetById(id));
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteStudent(IRepository<Student> repository, string id)
        {
            try
            {
                return TypedResults.Ok(repository.DeleteById(id));
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult AddStudent(IRepository<Student> repository, AddStudentDTO addStudent)
        {
            Student student = new()
            {
                FirstName = addStudent.FirstName,
                LastName = addStudent.LastName,
            };
            return TypedResults.Created(nameof(GetStudent), repository.Add(student));
        }

        public static IResult PutStudent(IRepository<Student> repository, string id, AddStudentDTO changeStudent)
        {
            try
            {
                Student student = repository.GetById(id);
                student.FirstName = changeStudent.FirstName;
                student.LastName = changeStudent.LastName;
                return TypedResults.Ok(student);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }

        }
    }
}
