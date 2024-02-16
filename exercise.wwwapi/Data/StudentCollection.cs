using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class StudentCollection
    {
        public List<Student> Students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        public Student AddStudent(StudentCreatePayload studentData)
        {   
            var newStudent = new Student() { FirstName = studentData.FirstName, LastName = studentData.LastName };
            Students.Add(newStudent);
            return newStudent;
        }

        public List<Student> GetAll()
        {
            return Students;
        }

        public Student GetStudent(string firstName)
        {
            return Students.FirstOrDefault(s => s.FirstName == firstName);
        }

        public Student UpdateStudent(string firstName, StudentUpdatePayload newStudent)
        {
            var student = GetStudent(firstName);
            if (student == null)
            {
                return null;
            }
            student.FirstName = newStudent.FirstName ?? student.FirstName;
            student.LastName = newStudent.LastName ?? student.LastName;
            return student;
        }

        public Student DeleteStudent(string firstName)
        {
            var student = GetStudent(firstName);
            return Students.Remove(student) ? student : null;
        }
    };


}
