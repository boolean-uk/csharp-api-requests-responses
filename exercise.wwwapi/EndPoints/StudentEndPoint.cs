using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.EndPoints
{
    public static class StudentEndPoint
    {
        public static void ConfigureStudentEndPoint(this WebApplication app)
        {
            var StudentGroup = app.MapGroup("/students");
            StudentGroup.MapGet("/", GetAllStudents);
            StudentGroup.MapPost("/", AddStudent);
            StudentGroup.MapGet("/{firstName}", GetStudent);
            StudentGroup.MapDelete("/{firstName}", DeleteStudent);
            StudentGroup.MapPut("/{firstName}", UpdateStudent);
        }

        public static IResult GetAllStudents(IStudentRepository studentRepository)
        {
            try
            {
                return TypedResults.Ok(studentRepository.GetAllStudents());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static IResult AddStudent(IStudentRepository studentRepository,string firstName, string lastName)
        {
            try
            {
                Student student = studentRepository.AddStudent(firstName, lastName);
                return TypedResults.Created($"/students/{student.FirstName}", student);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    
        public static IResult GetStudent(IStudentRepository studentRepository, string firstName)
        {
            try
            {
                Student? student = studentRepository.GetStudent(firstName);
                if (student == null)
                {
                    return TypedResults.NotFound();
                }

                return TypedResults.Ok(student);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        public static IResult DeleteStudent(IStudentRepository studentRepository, string firstName)
        {
            try
            {
                Student? student = studentRepository.DeleteStudent(firstName);
                if (student == null)
                {
                    return TypedResults.NotFound();
                }

                return TypedResults.Ok(student);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        public static IResult UpdateStudent(IStudentRepository studentRepository, string firstName, StudentUpdatePayload studentUpdatePayload)
        {
            try
            {
                Student? student = studentRepository.UpdateStudent(firstName, studentUpdatePayload);
                if (student == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(student);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}