using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapGet("/", GetAll);
            students.MapGet("/{firstName}", Get);
            students.MapPost("/", Create);
            students.MapPut("/{firstName}", Update);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAll(IRepository<Student> repository) 
        {
            Payload<List<Student>> payload = new Payload<List<Student>>();
            payload.data = repository.GetAll();
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult Get(IRepository<Student> repository, string firstName)
        {
            Payload<Student> payload = new Payload<Student>();
            payload.data = repository.Get(firstName);

            if (payload.data == null)
            {
                return TypedResults.NotFound($"Student with firstName {firstName} not found.");
            }

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult Create(IRepository<Student> repository, Student model)
        {
            Payload<Student> payload = new Payload<Student>();
            payload.data = repository.Add(model);
            if (payload.data == null)
            {
                return TypedResults.BadRequest($"Student with firstName {model.FirstName} and lastName {model.LastName} already exists.");
            }
            return TypedResults.Created($"https://localhost:7068/students/{payload.data.FirstName}", payload.data);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult Update(IRepository<Student> repository, string firstName, Student model)
        {
            Payload<Student> payload = new Payload<Student>();
            payload.data = repository.Update(firstName, model);
            if (payload.data == null)
            {
                return TypedResults.NotFound($"Student with firstName {firstName} not found.");
            }
            return TypedResults.Created($"https://localhost:7068/students/{payload.data.FirstName}", payload.data);
        }
    }
}
