using exercise.wwwapi.Models;
using System.Net.NetworkInformation;
using exercise.wwwapi.Data;

namespace exercise.wwwapi.Endpoints
{
    public static class StudentEndpoints
    {
        public static IResult CreateStudent(string firstName, string lastName, StudentCollection students)
        { 
            Student newStudent = students.Create(firstName, lastName);

            return Results.Created($"/CreateStudent/{firstName}/{lastName}", newStudent);
        }

        public static IResult GetAllStudents(StudentCollection students )
        {
            var allStudents = students.getAll();
            return Results.Ok(allStudents);
        }
        
        public static IResult GetAStudent(StudentCollection students, string firstName)
        {
            var student = students.getAll().Find(s => s.FirstName == firstName);

            if (student != null)
            {
                return TypedResults.Ok(student);
            }
            else
            {
                return Results.NotFound($"Student with first name {firstName} not found");
            }
        }
        
        
        public static IResult UpdateAStudent(StudentCollection students, string firstName, string NewName)
        {
            var student = students.getAll().FirstOrDefault(s => s.FirstName == firstName);

            if (student != null)
            {
                student.FirstName = NewName;
                string lastName = student.LastName;
                return TypedResults.Created($"/UpdatedStudent/{firstName}/{lastName}", student);
            }
            else
            {
                return Results.NotFound($"Student with first name {firstName} not found");
            }
        }

        public static IResult DeleteStudent(StudentCollection students, string firstName)
        {
            var student = students.getAll().FirstOrDefault(s => s.FirstName == firstName);

            if (student != null)
            {
                students.Remove(student);
                string lastName = student.LastName;
                return TypedResults.Ok(student);
            }
            else
            {
                return Results.NotFound($"Student with first name {firstName} not found");
            }
        }


    }
}
