using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentsEndpoint
    {
        public static void ConfigureStudentsEndpoint(this WebApplication app)
        {
            var studentGroup = app.MapGroup("students");
            studentGroup.MapGet("/", GetStudents);
            studentGroup.MapPost("/", PostStudent);
            studentGroup.MapGet("/{name}", GetStudent);
            studentGroup.MapPut("/{name}",UpdateStudent);
            studentGroup.MapDelete("/{name}", DeleteStudent);
        }

        public static async Task<IResult> GetStudents(IRepository repository)
        {
            return TypedResults.Ok(repository.GetStudents());
        }

        public static async Task<IResult> PostStudent(IRepository repository, Student student)
        {
            return TypedResults.Created("",repository.AddStudent(student));
        }

        public static async Task<IResult> GetStudent(IRepository repository, string name)
        {
            return TypedResults.Ok(repository.GetStudent(name));
        }

        public static async Task<IResult> UpdateStudent(IRepository repository, string name, Student student)
        {
            return TypedResults.Ok(repository.UpdateStudent(name, student));
        }

        public static async Task<IResult> DeleteStudent(IRepository repository, string name)
        {
            repository.DeleteStudent(name);
            return TypedResults.Ok();
        }
    }
}
