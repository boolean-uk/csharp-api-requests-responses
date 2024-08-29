using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var students = app.MapGroup("students");

            students.MapPost("/", AddStudent);
            students.MapGet("/", GetAllStudents);
            students.MapGet("/{firstName}", GetaStudent);
            students.MapPut("/{firstName}", UpdateStudent);
            students.MapDelete("/{firstName}", DeleteStudent);

        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult AddStudent(IRepository<Student> rep, Student student)
        {
            Payload<Student> payload = new Payload<Student>();
            payload.Data = rep.Add(student);

            return TypedResults.Ok(payload);
        } 
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllStudents(IRepository<Student> rep)
        {
            List<Student> students = new List<Student>();
            students = rep.GetAll();

            return TypedResults.Ok(students);
        } 
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetaStudent(IRepository<Student> rep, string firstname)
        {
            Student student = new Student();
            student = rep.Get(firstname);

            return TypedResults.Ok(student);
        } 
        
        
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static IResult UpdateStudent(IRepository<Student> rep, string firstname, Student student)
        {
            Payload<Student> payload = new Payload<Student>();
            payload.Data = rep.Update(firstname, student );

            return TypedResults.Ok(payload);   
        } 
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult DeleteStudent(IRepository<Student> rep, string firstname)
        {

            Student student = new Student();
            student = rep.Delete(firstname);

            return TypedResults.Ok(student);
        }
    }
}
