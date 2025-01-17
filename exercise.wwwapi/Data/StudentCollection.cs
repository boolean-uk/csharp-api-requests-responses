using System.ComponentModel.DataAnnotations;
using exercise.wwwapi.Models;

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
            if (_students.Where(s => s.Equals(student)).ToList().Count == 0) // First and Last name are search critera, so they have to be unique
            {     
                _students.Add(student);

                return student;
            }
            return null; // So we can provide a 403 - Already Exists response
        }

        public static List<Student> GetAll()
        {
            return _students.ToList();
        }

        public static Student Get(string firstName)
        {
            return _students.FirstOrDefault(s => s.FirstName == firstName);
        }


        public static bool Delete(string firstName)
        {
            Student entity = _students.FirstOrDefault(s => s.FirstName == firstName);

            if (entity == null)
            {
                return false;
            }

            return _students.RemoveAll(s => s.Equals(entity)) > 0;
        }

        public static Student Update(string firstName, Student updatedEntity)
        {
           
            try 
            {
                _students.Where(s => s.FirstName == firstName).ToList().ForEach(toUpdate => toUpdate.Update(updatedEntity));

                Student newStud = _students.FirstOrDefault(updated => updated.Equals(updatedEntity)); // This should always return a student
                return newStud;
            }
            catch (Exception e)
            {
                return null; // So we can return a 404 - Not Found response
            }
        }
    }


}
