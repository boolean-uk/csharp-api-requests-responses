using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Reposity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class EndpointsStudents
    {
        public static void ConfigueEndPointStudents(this WebApplication app)
        {
            var students = app.MapGroup("Students");
            students.MapPost("/", PostStudents);
            students.MapGet("/", GetAll);
            students.MapGet("/{FirstName}", Get);
            students.MapPut("/{FirstName}", Update);
            students.MapDelete("/{FirstName}", Delete);
        }

        public static IResult PostStudents(IRepository<Student> students, Student student)
        {
            students.Add(student);
            return TypedResults.Created("/", student);
        }

        public static IResult GetAll(IRepository<Student> students)
        {
            return TypedResults.Ok(students.getAll());
        }

        public static IResult Get(IRepository<Student> students, string FirstName)
        {
            return TypedResults.Ok(students.Get(FirstName));
        }

        public static IResult Update(IRepository<Student> students, string FirstName, Student student)
        {
            return TypedResults.Ok(students.Update(FirstName, student));
        }

        public static IResult Delete(IRepository<Student> students, string FirstName)
        {
            return TypedResults.Ok(students.Delete(FirstName));
        }
    }
}
