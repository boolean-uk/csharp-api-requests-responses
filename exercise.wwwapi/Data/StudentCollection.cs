using exercise.wwwapi.Models;
using System.Net.NetworkInformation;

namespace exercise.wwwapi.Data
{
    public static class StudentCollection
    {

        private static List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        public static Student Add(Student student)
        {
            _students.Add(student);

            return student;
        }

        public static List<Student> getAll()
        {
            return _students.ToList();
        }
        public static Student GetA(string firstName)
        {
            return _students.FirstOrDefault(x => x.FirstName == firstName);
        }

        public static Student Change(string search, Student entity)
        {
            foreach (var student in _students)
            {
                if (student.FirstName == search)
                {
                    student.FirstName = entity.FirstName;
                    student.LastName = entity.LastName;
                }
            }
            return entity;
        }
        public static string Delete(string search)
        {
            foreach (var student in _students)
            {
                if (student.FirstName.Equals(search))
                {
                    _students.Remove(student);
                    return search;
                }
                
            }
            return null;
        }
    };


}
