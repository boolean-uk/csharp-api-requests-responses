using exercise.wwwapi.Models;
using System.Diagnostics;

namespace exercise.wwwapi.Data
{
    public class StudentCollection
    {
        private List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        public Student Add(Student student)
        {            
            _students.Add(student);

            return student;
        }

        public List<Student> getAll()
        {
            return _students.ToList();
        }

        public Student GetStudent(string firstname) 
        {
            Student student = _students.First(x => x.FirstName == firstname);
            return student;
        }

        public Student UpdateStudent (string firstname, Student student) 
        {                        
            Student retrievedStudent = this._students.Find(x => x.FirstName == firstname);
            retrievedStudent.FirstName = student.FirstName;
            retrievedStudent.LastName = student.LastName;            
            return retrievedStudent;
        }

        public Student DeleteStudent(string firstName) 
        {
            Student student = this._students.First(x => x.FirstName == firstName);
            this._students.Remove(student);
            return student;
        } 
    }


}
