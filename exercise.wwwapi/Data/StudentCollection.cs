using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

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


        public static Student Get(string firstName)
        {
            return _students.FirstOrDefault(p => p.FirstName == firstName);
        }
        public static Student Add(Student entity)
        {
            _students.Add(entity);
            return entity;

        }
        public static bool Remove(string FirstName)
        {
            return _students.RemoveAll(p => p.FirstName == FirstName) > 0 ? true : false;

        }

        public static List<Student> Students { get {  return _students; } }

      
    };


}
