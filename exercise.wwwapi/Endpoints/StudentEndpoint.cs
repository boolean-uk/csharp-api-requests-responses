using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using exercise.wwwapi.Models;
using exercise.wwwapi.Models.DTO;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndpoint(this WebApplication app)
        {
            var studentGroup = app.MapGroup("students");

            studentGroup.MapGet("/", GetStudents); //get all
            studentGroup.MapGet("/{provideName}", GetAStudent); //get a 
            studentGroup.MapPost("/{providedName}", AddStudent); //add
            studentGroup.MapDelete("/{providedName}", DeleteStudent); //delete
            studentGroup.MapPut("/{provideName}", UpdateStudent); //update
        }


        //get all
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository<Student> studentRepository)
        {
            var results = await studentRepository.Get();
            Payload<IEnumerable<Student>> payload = new Payload<IEnumerable<Student>>();
            payload.data = results;
            return Results.Ok(payload);
        }


        //get a
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAStudent(IRepository<Student> studentRepository, string providedName)
        {
            var students = await studentRepository.Get();
            if (students.Any(x => x.FirstName.Equals(providedName, StringComparison.OrdinalIgnoreCase)))
            {
                var student = students.Where(x => x.FirstName.Equals(providedName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                return Results.Ok(student);
            }
            else
            {
                return Results.NotFound("Student not found");
            }
        }


        //add
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddStudent(IRepository<Student> studentRepository, StudentPost newstudent)
        {
            var students = await studentRepository.Get();
            if (students.Any(x => x.FirstName.Equals(newstudent.Firstname, StringComparison.OrdinalIgnoreCase)))
            {
                var firstnameMatches = students.Where(x => x.FirstName.Equals(newstudent.Firstname, StringComparison.OrdinalIgnoreCase));
                foreach (var student in firstnameMatches) 
                {
                    if (student.LastName.Equals(newstudent.Lastname, StringComparison.OrdinalIgnoreCase))
                    {
                        return Results.BadRequest("Student already exists");
                    }
                }
                int id = students.Max(x => x.Id) + 1;
                var entity = new Student() { Id = id, FirstName = newstudent.Firstname, LastName = newstudent.Lastname };
                studentRepository.Insert(entity);
                return TypedResults.Created($"/{entity}");
            }
            else
            {
                int id = students.Max(x => x.Id) + 1;
                var entity = new Student() { Id = id, FirstName = newstudent.Firstname, LastName = newstudent.Lastname };
                studentRepository.Insert(entity);
                return TypedResults.Created($"/{entity}");
            }
        }


        //delete
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> DeleteStudent(IRepository<Student> studentRepository, string firstname, string lastname)
        {
            var students = await studentRepository.Get();
            if (students.Any(x => x.FirstName.Equals(firstname, StringComparison.OrdinalIgnoreCase)))
            {
                var firstnameMatches = students.Where(x => x.FirstName.Equals(firstname, StringComparison.OrdinalIgnoreCase));
                foreach (var student in firstnameMatches)
                {
                    if (student.LastName.Equals(lastname, StringComparison.OrdinalIgnoreCase))
                    {
                        //delete this student
                        var student_todelete = student;
                        var id = student.Id;
                        studentRepository.Delete(id);
                        return Results.Ok("Student deleted: " + student.FirstName + " " + student.LastName);
                    }
                }
                return Results.BadRequest("Student not found");
            }
            else
            {
                return Results.BadRequest("Student not found");
            }
        }


        //update
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdateStudent(IRepository<Student> studentRepository, string selectstudent_firstname, string selectstudent_lastname, StudentPut updatestudent)
        {
            var students = await studentRepository.Get();
            if (students.Any(x => x.FirstName.Equals(selectstudent_firstname, StringComparison.OrdinalIgnoreCase)))
            {
                var firstnameMatches = students.Where(x => x.FirstName.Equals(selectstudent_firstname, StringComparison.OrdinalIgnoreCase));
                foreach (var student in firstnameMatches)
                {
                    if (student.LastName.Equals(selectstudent_lastname, StringComparison.OrdinalIgnoreCase))
                    {
                        //update this student
                        var student_toupdate = student;
                        student.FirstName = updatestudent.Firstname;
                        student.LastName = updatestudent.Lastname;

                        var id = student.Id;
                        await studentRepository.Update(student);
                        return TypedResults.Created($"/{student}");
                    }
                }
                return Results.BadRequest("Student not found");
            }
            else
            {
                return Results.BadRequest("Student not found");
            }
        }
    }
}
