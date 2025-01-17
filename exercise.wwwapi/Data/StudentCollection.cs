using System.Reflection.Metadata.Ecma335;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class StudentCollection
    {
        private static List<Student> _students = new List<Student>();

        public static void Initialize()
        {
            _students.Add(new Student() { FirstName = "Nathan", LastName = "King" });
            _students.Add(new Student() { FirstName = "Dave", LastName = "Ames" });
        }


        public static Student Add(Student student)
        {            
            _students.Add(student);

            return student;
        }

        public static List<Student> getAll()
        {
            return _students.ToList();
        }

        public static Student GetStudent(string firstName)
        {
            return _students.FirstOrDefault(x => x.FirstName.ToLower() == firstName.ToLower());
        }

        public static bool Remove(string firstName)
        {
            return _students.RemoveAll(x => x.FirstName.ToLower() == firstName.ToLower()) > 0 ? true : false;
        }

    };


}
