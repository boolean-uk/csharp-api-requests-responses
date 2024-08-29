using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoints
    {
        public static void ConfigureStudentEndpoints(this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapGet("", GetStudents);
            students.MapGet("/{firstname}", GetStudent);
            students.MapPost("", Add);
            students.MapPut("/{firstname}", Update);
            students.MapDelete("/{firstname}", Delete);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetStudents(IRepo<Student, string> studRepository)
        {
            return TypedResults.Ok(studRepository.getAll());
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult Add(IRepo<Student, string> studRepository, Student student)
        {
            studRepository.Add(student);

            return TypedResults.Created();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetStudent(IRepo<Student, string> studRepository, string firsname)
        {
            Student student = studRepository.Get(firsname);
            if (student == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult Update(IRepo<Student, string> studRepository, Student student, string firstname)
        {
            Student oldstudent = studRepository.Get(firstname);
            if (oldstudent == null)
            {
                return TypedResults.NotFound();
            }
            if(student == null)
            {
                return TypedResults.BadRequest();
            }

            studRepository.Update(student, firstname);
            return TypedResults.Created();
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult Delete(IRepo<Student, string> studRepository, string firstname)
        {
            Student student = studRepository.Get(firstname);
            if (student == null)
            {
                return TypedResults.NotFound();
            }

            studRepository.Delete(firstname);

            return TypedResults.Ok();
        }



    }
}
