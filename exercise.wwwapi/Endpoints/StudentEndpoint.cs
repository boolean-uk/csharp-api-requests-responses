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
            studentGroup.MapGet("/{firstName}", GetAStudent);
            studentGroup.MapPost("/", Create);
            studentGroup.MapPut("/{firstName}", Update);
            studentGroup.MapDelete("/{firstName}", Delete);

            }

            [ProducesResponseType(StatusCodes.Status200OK)]

            public static async Task<IResult> GetStudents(IStudentRepository repository)
            {
            IEnumerable<Student> list = repository.GetList();
                return TypedResults.Ok(list);
            }

            [ProducesResponseType(StatusCodes.Status200OK)]
            public static async Task<IResult> GetAStudent(IStudentRepository repository, string input)
            {
            Student student = repository.Get(input);
                return TypedResults.Ok(student);
            }


            [ProducesResponseType(StatusCodes.Status201Created)]

            public static async Task<IResult> Create(IStudentRepository repository, Student model)
            {
                Student newStudent = new Student() {FirstName=model.FirstName,LastName=model.LastName };
                repository.Create(newStudent);
                return TypedResults.Created($"/{newStudent.FirstName}",newStudent);
            }


            [ProducesResponseType(StatusCodes.Status201Created)]

            public static async Task<IResult> Update(IStudentRepository repository, string input)
            {
                Student updated = (Student)repository.Update(input);
                return TypedResults.Ok(updated);
            }

            [ProducesResponseType(StatusCodes.Status200OK)]
            public static async Task<IResult> Delete(IStudentRepository repository, string input)
            {
                Student Deleted = repository.Delete(input);
                return TypedResults.Ok(Deleted);
            }

        }
    }



