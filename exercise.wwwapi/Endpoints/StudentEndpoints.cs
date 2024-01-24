using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Endpoints


{
    public class StudentEndpoints
    {


        public static IResult AddStudent(StudentCollection students, string firstName, string lastName)
        {
            Student newStud = new Student() { FirstName = firstName, LastName = lastName};
            students.Add(newStud);
            return TypedResults.Created($"/students{newStud.FirstName}", newStud);
        }
        public static IResult GetAllStudents(StudentCollection students)
        {
            return TypedResults.Ok(students.GetAllStudents());
        }

        public static IResult GetStudent(StudentCollection students, string firstName)
        {
            Student student = students.GetStudent(firstName);
            return TypedResults.Ok(student);
        }
        public static IResult UpdateStudent(StudentCollection students, string nametoUpdate, string firstName, string lastName)
        {
            

            try
            {
                Student? updatedStudent = new Student() { FirstName = firstName, LastName = lastName };
                if(updatedStudent == null)
                {
                    return Results.NotFound($"Student with first name {nametoUpdate} not found.");
                }
                students.UpdateStudent(nametoUpdate, updatedStudent);
                return TypedResults.Created($"/students{updatedStudent.FirstName}", updatedStudent);
            }
            catch(Exception e)
            {
                return Results.BadRequest(e.Message);
            }
            
            
           
        }

        public static IResult DeleteStudent(StudentCollection students, string firstName, string lastName)
        {
            return TypedResults.Ok(students.RemoveStudent(firstName, lastName));
        }


    }
}
