using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndpoints(this WebApplication app)
        {
            var studentGroup = app.MapGroup("students");

            studentGroup.MapGet("/", GetStudents);
            studentGroup.MapGet("/{name}", GetStudent);
            studentGroup.MapPost("/", AddStudent).AddEndpointFilter(async (invocationContext, next) =>
            {
                var student = invocationContext.GetArgument<StudentPost>(1);
                
                if (string.IsNullOrEmpty(student.FirstName) || string.IsNullOrEmpty(student.LastName))
                {
                    return Results.BadRequest("You must enter a Firstname AND Lastname");
                }
                if (string.Equals(student.FirstName, "string") || string.Equals(student.LastName, "string")) 
                {
                    return Results.BadRequest("Please change 'string' to your name");
                }
                return await next(invocationContext);
            }); ; ;
            studentGroup.MapPut("/{name}", UpdateStudent);
            studentGroup.MapDelete("/{name}", DeleteStudent);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepo<Student> student)
        {
            var result = student.GetAll();
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudent(IRepo<Student> student, string name)
        {
            var studentEntity = student.GetAll().FirstOrDefault(x => x.FirstName == name || x.LastName == name);
            if (studentEntity != null)
            {
                return TypedResults.Ok(studentEntity);
            }
            else
            {
                return TypedResults.NotFound("Student not found");
            }

        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddStudent(IRepo<Student> student, StudentPost newstudent)
        {
            if (student.GetAll().Any(x => x.FirstName.Equals(newstudent.FirstName, StringComparison.OrdinalIgnoreCase) &&
             student.GetAll().Any(y => y.LastName.Equals(newstudent.LastName, StringComparison.OrdinalIgnoreCase))))
            {
                return Results.BadRequest("Student with provided name already exists");
            }

            var entity = new Student() { FirstName = newstudent.FirstName, LastName = newstudent.LastName };
            student.Add(entity);
            return TypedResults.Created($"/{entity.FirstName}", entity);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> UpdateStudent(IRepo<Student> student, string oldname, StudentPut newname)
        {
            var studentEntity = student.GetAll().FirstOrDefault(x => x.FirstName == oldname || x.LastName == oldname);
            if (studentEntity == null)
            {
                return TypedResults.NotFound("Name not found");
            }

            if (newname.FirstName != null)
            {
                studentEntity.FirstName = newname.FirstName;
            }

            if (newname.LastName != null)
            {
                studentEntity.LastName = newname.LastName;
            }

            student.Update(studentEntity);

            return TypedResults.Created($"/{studentEntity.FirstName}", studentEntity);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IRepo<Student> student, string name)
        {
            if (!student.GetAll().All(y => y.FirstName == name))
            {
                return TypedResults.NotFound("Student not found");
            }
            var entity = student.Remove(x => x.FirstName == name);
            return entity != null ? TypedResults.Ok(entity) : TypedResults.NotFound();
        }
    }
}
