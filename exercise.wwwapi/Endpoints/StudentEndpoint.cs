using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoint
    {
        public static void ConfigureStudentEndpoints(this WebApplication app)
        {
            var students = app.MapGroup("students");
            students.MapGet("/", getAll);
            students.MapGet("/singleStudent/", getAStudent);
            students.MapPost("/", Add);
            students.MapPut("/{firstname}", updateStudent);
            students.MapDelete("/{firstname}", deleteStudent);
        }
        public static IResult getAll(IStudentRepository students) {
            return TypedResults.Ok(students.getAll());    
        }
        public static IResult Add(IStudentRepository students, StudentPostPayload newStudentData)
        {
            Student student = students.Add(newStudentData.Student);
            return TypedResults.Created($"/students{student.FirstName}", student);
        } 
        public static IResult getAStudent(IStudentRepository students, string name)
        {
            Student? student = students.getAStudent(name);
            if (student == null)
            {
                return Results.NotFound($"Student with firstname {name} not found.");
            }
            return TypedResults.Ok(student);
        }
        public static IResult updateStudent(IStudentRepository students, string firstname, string newfirstname, string lastname)
        {
            try
            { 
                Student? item = students.updateStudent(firstname, newfirstname, lastname);
                if (item == null)
                {
                    return Results.NotFound($"Student with firstname {firstname} not found.");
                }
                return TypedResults.Created($"/students{item.FirstName}", item);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

        public static IResult deleteStudent(IStudentRepository students, string firstname)
        {
            try
            {
                Student? item = students.deleteAStudent(firstname); 
                if (item == null)
                {
                    return Results.NotFound($"Student with firstname {firstname} not found.");
                }
                return Results.Ok(item);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message); 
            }
        }
    }
}