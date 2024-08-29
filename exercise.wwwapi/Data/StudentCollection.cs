using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class StudentCollection
    {
        private static List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        public static Student CreateAStudent(Student student)
        {            
            _students.Add(student);
            return student;
        }

        public static List<Student> GetAllStudents()
        {
            return _students;
        }

        public static Student GetAStudent(string firstname) 
        { 
            
            return _students.FirstOrDefault(x => x.FirstName == firstname);
        }

        public static Student UpdateStudent(string firstname, string newFirstname, string newLastname) 
        {
            Student updatedStudent = _students.FirstOrDefault(x => x.FirstName == firstname);
            updatedStudent.FirstName = newFirstname;
            updatedStudent.LastName = newLastname;

            return updatedStudent;

        }

        public static Student DeleteStudent(string firstname) 
        { 
            Student deleteStudent = _students.FirstOrDefault(x=> x.FirstName == firstname);
            _students.Remove(deleteStudent);

            return deleteStudent;
        }
    };


}
