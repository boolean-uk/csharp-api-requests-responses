using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.Endpoints
{
    [ApiController]
    [Route("student")]
    public static class StudentEndpoints
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var studentGroup = app.MapGroup("");

            studentGroup.MapPost("/create a student", AddStudent);
            studentGroup.MapGet("/get all students", GetStudents);
            studentGroup.MapGet("/{id}", AddStudent);
            studentGroup.MapPut("/update a student {name}", UpdateStudent);
            studentGroup.MapDelete("/delete student{id}", DeleteStudent);
        }



        // get all students

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents([FromServices] IRepository repository)
        {
            return TypedResults.Ok(repository.GetStudents());
        }



        // create a student or add a student
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddStudent([FromServices] IRepository repository, [FromBody] StudentPost student)
        {
            //validate
            if (student == null)
            {

            }
            var newStudent = new Student() { FirstName = student.FirstName, LastName = student.LastName };
            repository.AddStudent(newStudent);
            return TypedResults.Created($"/{newStudent.FirstName}", newStudent);
        }


        // update a student
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateStudent([FromServices] IRepository repository, int id, [FromBody] StudentPut name)
        {
            return TypedResults.Ok(repository.UpdateStudent(id, name));
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(int id, IRepository repository)
        {
            var studentDeleted = repository.DeleteStudent(id);
            return TypedResults.Ok(studentDeleted);



        }
    }
}
