
using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoints 
    {
        public static void ConfigureStudentEndpoints(this WebApplication app) 
        {
            var students = app.MapGroup("students");
            students.MapGet("/", GetAll);
            students.MapGet("/{firstName}", GetA);
            students.MapPost("/{student}", Create);
            students.MapPut("/{firstName}", Update);
            students.MapDelete("/{firstName}", Delete);

        }

        private static IResult GetAll(StudentRepository repo) => TypedResults.Ok(repo.GetAll());

        private static IResult GetA(StudentRepository repo, string firstName) => TypedResults.Ok(repo.GetA(firstName));
        private static IResult Create(StudentRepository repo, Student student) => TypedResults.Created($"http://localhost:5115/book/id/{student.FirstName}", repo.Create(student)); 

        private static IResult Update(StudentRepository repo, string firstName) => TypedResults.Created($"http://localhost:5115/book/id/{firstName}", repo.Update(firstName));

        private static IResult Delete(StudentRepository repo, string firstName) => TypedResults.Ok(repo.Delete(firstName));
    }
}
