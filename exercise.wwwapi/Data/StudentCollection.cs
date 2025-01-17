using System.Runtime.ExceptionServices;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class StudentCollection
    {
        private static List<Student> _students = new List<Student>();

        public static void Initialize()
        {
            _students.Add(new Student { FirstName = "Nathan", LastName = "King" });
            _students.Add(new Student { FirstName = "Dave", LastName = "Ames" });
        }
        public static List<Student> Students { get { return _students; } }
       
        public static Student Get(string firstName)
        {
            return _students.FirstOrDefault(s => s.FirstName == firstName);
        }
        public static Student Add(Student student)
        {
            var existingStudent = _students.FirstOrDefault(s => s.FirstName == student.FirstName);
            if(existingStudent != null)
            {
                _students.Add(student);
            }
            return student;
        }
        public static Student Update(string firstName, Student student)
        {
            var existingStudent = _students.FirstOrDefault(s => s.FirstName == firstName);
            if (existingStudent != null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
            }
            return existingStudent;
        }
        public static bool DeleteStudent(string firstName) 
        {
            return _students.RemoveAll(s => s.FirstName == firstName) > 0 ? true : false;
        }
    }


}
