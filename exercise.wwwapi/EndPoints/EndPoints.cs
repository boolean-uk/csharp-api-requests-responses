using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.EndPoints
{
    public static class StudentEndPoints
    {


        public static void ConfigureStudentEndpoints(this WebApplication app)
        {
            var taskGroup = app.MapGroup("students");
            taskGroup.MapPost("/", AddStudent);
            taskGroup.MapGet("/", GetAllStudents);
            taskGroup.MapGet("/{FirstName}", GetStudentsWithFirstName);
            taskGroup.MapDelete("/{FirstName}", DeleteStudentsWithFirstName);
            taskGroup.MapPut("/{FirstName}", UpdateStudentWithFirstName);


            //taskGroup.MapPut("/{id}", UpdateTask);
        }

        public static IResult AddStudent(Student student, StudentCollection studentCollection
            )
        {
            
            studentCollection.Add(student);
            string url = "";
            return Results.Created(url, student);
        }

        public static IResult GetAllStudents(StudentCollection studentCollection
            )
        {

            return Results.Ok(studentCollection.getAll());
        }
        public static IResult GetStudentsWithFirstName(string FirstName, StudentCollection studentCollection
            )
        {
            List<Student> filt = studentCollection.getAll().Where(student => student.FirstName == FirstName).ToList();
            return Results.Ok(filt);
        }
        public static IResult DeleteStudentsWithFirstName(string FirstName, StudentCollection studentCollection )
        {
            Student? student = studentCollection.getAll().Where(student => student.FirstName == FirstName).ToList().FirstOrDefault();
           
            bool result = studentCollection.Delete(student);

            if (result) {  return Results.Ok(student); }
            return Results.BadRequest();
        }

        public static IResult UpdateStudentWithFirstName(string FirstName, Student updatedStudent, StudentCollection studentCollection)
        {
            Student? studentToUpdate = studentCollection.getAll().FirstOrDefault(s => s.FirstName == FirstName);

            if (studentToUpdate == null)
            {
                return Results.NotFound($"No student found with first name {FirstName}");
            }

            studentToUpdate.FirstName = updatedStudent.FirstName;
            studentToUpdate.LastName = updatedStudent.LastName;
            

            return Results.Ok(studentToUpdate);
        }




    }
}
