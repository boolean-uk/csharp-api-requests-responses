using exercise.wwwapi.Models;
using Microsoft.AspNetCore.SignalR;

namespace exercise.wwwapi.Data
{
    public static class StudentCollection
    {
        private static List<Student> _students = new List<Student>();

        public static void Initialize()
        {
            _students.Add(new Student() { FirstName="Nathan",LastName="King" });
            _students.Add( new Student() { FirstName="Dave", LastName="Ames" });
        }
        public static Student Add(Student student)
        {            
            _students.Add(student);

            return student;
        }

        public static List<Student> GetAll()
        {
            return _students;
        }

        public static Student GetStudent(string firstname)
        {
            return _students.FirstOrDefault(x => x.FirstName == firstname);
        }

        public static bool DeleteStudent(string firstname)
        {
            var student = _students.FirstOrDefault(x => x.FirstName == firstname);
            if (student == null)
            {
                return false;
            }
            _students.Remove(student);
            return true;
        }

        public static Student UpdateStudent(string firstname, Student student)
        {
            var existingStudent = _students.FirstOrDefault(x => x.FirstName == firstname);
            if (existingStudent == null)
            {
                return null;
            }
            existingStudent = student;
            return existingStudent;
        }
    };


}
